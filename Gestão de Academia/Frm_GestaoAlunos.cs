using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace Gestão_de_Academia
{
    public partial class Frm_GestaoAlunos : Form
    {
        string idSelecionado = "";
        int linha;
        string destinoCompleto;
        string fotoAntiga;

        public Frm_GestaoAlunos()
        {
            InitializeComponent();
        }

        private void Frm_GestaoAlunos_Load(object sender, EventArgs e)
        {
            string queryAlunos = String.Format(@"
            SELECT
                N_IDALUNO as 'ID',
                T_NOMEALUNO as 'Nome'
                FROM tb_alunos");
            Banco.AtualizarDGV(dgv_alunos, queryAlunos);
            VisualDGV();

            //Populando o cb_status
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A", "Ativa"); status.Add("P", "Paralisada"); status.Add("C", "Cancelada");
            cb_status.DataSource = new BindingSource(status,null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";
            cb_status.SelectedIndex = -1;

            //Query com subselect populando o cb_turmas
            string queryTurmas = String.Format(@"
            SELECT N_IDTURMA,
                ('Vagas: ' || ((N_MAXALUNOS)-(
                                                SELECT
                                                    count(tba.N_IDALUNO)
                                                FROM
                                                    tb_alunos as tba
                                                WHERE
                                                    tba.T_STATUS='A' and tba.N_IDTURMA=N_IDTURMA
                                             )
                                ) || ' / Turma: ' || T_DSCTURMA
                ) as 'Turma'
            FROM
                tb_turmas
            ORDER BY
                N_IDTURMA");
            cb_turmas.DataSource = Banco.dql(queryTurmas);
            cb_turmas.DisplayMember = "Turma";
            cb_turmas.ValueMember = "N_IDTURMA";
            idSelecionado = dgv_alunos.Rows[0].Cells[0].Value.ToString();
        }

        private void dgv_alunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv_alunos.SelectedRows.Count > 0)
            {
                idSelecionado = dgv_alunos.SelectedRows[0].Cells[0].Value.ToString();
                tb_nome.Text = dgv_alunos.SelectedRows[0].Cells[1].Value.ToString();
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                string queryCampos = String.Format(@"
                SELECT
                    N_IDALUNO,
                    T_NOMEALUNO,
                    T_TELEFONE,
                    T_STATUS,
                    N_IDTURMA,
                    T_FOTO
                    FROM
                        tb_alunos
                            WHERE N_IDALUNO={0}"
                ,idSelecionado);
                DataTable dt = Banco.dql(queryCampos);
                tb_nome.Text = dt.Rows[0].Field<string>("T_NOMEALUNO");
                mtb_telefone.Text = dt.Rows[0].Field<string>("T_TELEFONE");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("T_STATUS");
                cb_turmas.SelectedValue = dt.Rows[0].Field<Int64>("N_IDTURMA");
                pb_foto.ImageLocation = dt.Rows[0].Field<string>("T_FOTO");
                fotoAntiga = pb_foto.ImageLocation;
            }            
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente salvar?", "Salvar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string queryAtt = String.Format($@"
                UPDATE tb_alunos
                    SET
                        T_NOMEALUNO='{tb_nome.Text}',
                        T_TELEFONE='{mtb_telefone.Text}',
                        T_STATUS='{cb_status.SelectedValue}',
                        N_IDTURMA='{cb_turmas.SelectedValue}',
                        T_FOTO='{pb_foto.ImageLocation}'
                    WHERE
                        N_IDALUNO={idSelecionado}");
                Banco.dql(queryAtt);
                linha = dgv_alunos.SelectedRows[0].Index;
                dgv_alunos[1, linha].Value = tb_nome.Text;
                VisualDGV();
                //=============ATENÇÃO==================//
                if (fotoAntiga != pb_foto.ImageLocation)
                {
                    File.Copy(pb_foto.ImageLocation, fotoAntiga, true);
                }
            }            
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (File.Exists(pb_foto.ImageLocation))
                {
                    File.Delete(pb_foto.ImageLocation);
                }

                string queryDel = String.Format($@"
                DELETE FROM tb_alunos
                    WHERE N_IDALUNO={idSelecionado}");
                Banco.AtualizarDGV(dgv_alunos, queryDel);
                queryDel = String.Format(@"
                    SELECT
                        N_IDALUNO as 'ID',
                        T_NOMEALUNO as 'Nome'
                        FROM tb_alunos");
                Banco.AtualizarDGV(dgv_alunos, queryDel);
            }
            VisualDGV();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pb_foto_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                destinoCompleto = openFileDialog.FileName;
            }
            if (File.Exists(destinoCompleto))
            {
                string update = String.Format($@"
                UPDATE tb_alunos
                    SET T_FOTO='{destinoCompleto}'
                        WHERE N_IDALUNO={idSelecionado}");
                Banco.dml(update);
                update = String.Format(@"
                SELECT T_FOTO
                    FROM tb_alunos
                        WHERE N_IDALUNO={0}"
                ,idSelecionado);
                DataTable dt = Banco.dql(update);
                pb_foto.ImageLocation = dt.Rows[0].Field<string>("T_FOTO");
                this.Refresh();                
            }
            else
            {
                MessageBox.Show("A foto não foi encontrada", "Error");
            }
        }

        private void VisualDGV()
        {
            dgv_alunos.Columns[0].Width = 40;
            dgv_alunos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        
        private void btn_financeiro_Click(object sender, EventArgs e)
        {

        }

        private void btn_imprimirCarteirinha_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminho + @"\carteirinha.pdf"; //Da nome ao arquivo
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create); //Cria o arquivo
            Document doc = new Document(PageSize.POSTCARD); //Cria o documento PDF para receber as informações
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF); //Pega o documento criado (doc) e preenche com o arquivo (arquivoPDF)

            iTextSharp.text.Image imagem = iTextSharp.text.Image.GetInstance(pb_foto.ImageLocation);
            PdfPCell celula = new PdfPCell();
            celula.Colspan = 3;
            celula.AddElement(imagem);

            PdfPTable tabela = new PdfPTable(3); 
            tabela.DefaultCell.FixedHeight = 20;

            tabela.AddCell(celula);

            Paragraph paragrafo = new Paragraph(string.Empty, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, (int)FontStyle.Bold));
            paragrafo.Add("Nome do Aluno: " + tb_nome.Text + "\n");
            paragrafo.Add("Telefone: " + mtb_telefone.Text + "\n");
            paragrafo.Add("Status: " + cb_status.Text + "\n");
            paragrafo.Add("Turma: " + cb_turmas.Text.Substring(18) + "\n");

            doc.Open();
            doc.Add(tabela);
            doc.Add(paragrafo);
            doc.Close();

            if (MessageBox.Show("Deseja abrir o relatório?", "Relatório", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Globais.caminho + @"\carteirinha.pdf"); //Abre o arquivo pdf
            }
        }
    }
}
