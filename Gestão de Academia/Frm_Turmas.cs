using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Importações funcionais para impressão:
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Gestão_de_Academia
{
    public partial class Frm_Turmas : Form
    {
        string idSelecionado;
        string queryDGV;

        public Frm_Turmas()
        {
            InitializeComponent();
        }

        private void Frm_Turmas_Load(object sender, EventArgs e)
        {
            queryDGV = $@"SELECT N_IDTURMA as 'ID', T_DSCTURMA as 'Turma', T_DSCHORARIO as 'Horário' FROM tb_turmas INNER JOIN tb_horarios on tb_horarios.N_IDHORARIO = tb_turmas.N_IDHORARIO";            
            dgv_turmas.DataSource = Banco.dql(queryDGV);
            VisualDGV();

            string queryProfessores = @"SELECT N_IDPROFESSOR, T_NOMEPROFESSOR FROM tb_professores ORDER BY N_IDPROFESSOR";
            cb_professor.DataSource = Banco.dql(queryProfessores);
            cb_professor.DisplayMember = "T_NOMEPROFESSOR";
            cb_professor.ValueMember = "N_IDPROFESSOR";

            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A", "Ativa");status.Add("P", "Paralisada"); status.Add("C", "Cancelada");
            cb_status.DataSource = new BindingSource(status,null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

            string queryHorarios = @"SELECT N_IDHORARIO, T_DSCHORARIO FROM tb_horarios ORDER BY T_DSCHORARIO";
            cb_horario.DataSource = Banco.dql(queryHorarios);
            cb_horario.DisplayMember = "T_DSCHORARIO";
            cb_horario.ValueMember = "N_IDHORARIO";
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_dscTurma.Clear();
            cb_professor.SelectedIndex = -1;
            n_maxAlunos.Value = 0;
            cb_status.SelectedIndex = -1;
            cb_horario.SelectedIndex = -1;
            dgv_turmas.ClearSelection();
            tb_dscTurma.Focus();
            idSelecionado = "0";
        }

        private void dgv_turmas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataTable dt;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv_turmas.Rows[dgv_turmas.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = $@"SELECT T_DSCTURMA, N_IDPROFESSOR, N_IDHORARIO, N_MAXALUNOS, T_STATUS FROM tb_turmas WHERE N_IDTURMA={idSelecionado}";
                dt = Banco.dql(vqueryCampos);
                tb_dscTurma.Text = dt.Rows[0].Field<String>("T_DSCTURMA");
                cb_professor.SelectedValue = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString();
                n_maxAlunos.Value = dt.Rows[0].Field<Int64>("N_MAXALUNOS");
                cb_status.SelectedValue = dt.Rows[0].Field<String>("T_STATUS");
                cb_horario.SelectedValue = dt.Rows[0].Field<Int64>("N_IDHORARIO").ToString();
            }

            string queryContagem = $@"SELECT count(N_IDALUNO) as 'count' FROM tb_alunos WHERE T_STATUS='A' and N_IDTURMA="+idSelecionado;
            dt = Banco.dql(queryContagem);
            int vagas = Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString());
            vagas -= Int32.Parse(dt.Rows[0].Field<Int64>("count").ToString());
            tb_vagas.Text = vagas.ToString();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string queryAtt;
            if (Convert.ToInt32(idSelecionado) != 0)
            {
                queryAtt = String.Format(@"UPDATE tb_turmas
                                                SET T_DSCTURMA='{0}',
                                                    N_IDPROFESSOR={1},
                                                    N_IDHORARIO={2},
                                                    N_MAXALUNOS={3},
                                                    T_STATUS='{4}'
                                                 WHERE N_IDTURMA={5}"
, tb_dscTurma.Text, cb_professor.SelectedValue, cb_horario.SelectedValue, Int64.Parse(Math.Round(n_maxAlunos.Value, 0).ToString()), cb_status.SelectedValue, idSelecionado);
                Banco.dql(queryAtt);
                dgv_turmas.DataSource = Banco.dql(queryDGV);
                MessageBox.Show("Valores atualizados");

            }
            else
            {
                queryAtt = $@"INSERT INTO tb_turmas
                                (T_DSCTURMA,N_IDPROFESSOR,N_IDHORARIO,N_MAXALUNOS,T_STATUS)
                                   VALUES ('{tb_dscTurma.Text}',{cb_professor.SelectedValue},{cb_horario.SelectedValue},{Int64.Parse(Math.Round(n_maxAlunos.Value, 0).ToString())},'{cb_status.SelectedValue}')";
                Banco.dql(queryAtt);
                dgv_turmas.DataSource = Banco.dql(queryDGV);
                MessageBox.Show("Valores inseridos");
            }
            VisualDGV();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirmar exclusão?", "Excluir", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string queryDelete = $@"DELETE FROM tb_turmas WHERE N_IDTURMA={idSelecionado}";
                Banco.dml(queryDelete);
                dgv_turmas.Rows.Remove(dgv_turmas.CurrentRow);
            }            
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminho + @"\turmas.pdf"; //Da nome ao arquivo
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create); //Cria o arquivo
            Document doc = new Document(PageSize.A4); //Cria o documento PDF para receber as informações
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF); //Pega o documento criado (doc) e preenche com o arquivo (arquivoPDF)

            //======================A   T   E   N   Ç   Ã   O==================================//
            //Adicionando uma imagem ao arquivo - Nota: A imagem deve estar dentro da pasta especificada nesse caso "Globais.caminho + @"\miniatura.png"
            iTextSharp.text.Image imagem = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\miniatura.jpg");
            imagem.Alignment = Element.ALIGN_CENTER; //Define o alinhamento da imagem
            imagem.WidthPercentage = 50;
            PdfPCell celula1 = new PdfPCell(); //Cria uma célula
            celula1.Colspan = 3; //Número de colunas que a célula ocupa
            celula1.AddElement(imagem);
            //imagem.ScaleToFit(70f, 60f);
            //imagem.ScaleToFit(imagem);
            //imagem.SetAbsolutePosition(100f, 700f); //Define a posição absoluta da imagem (X,Y) (de acordo com o plano Argand-Gauss)

            //Adicionando parágrafos ào arquivo
            Paragraph paragrafo = new Paragraph(string.Empty, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 20, (int)FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER; //Define o alinhamento do paragrafo
            paragrafo.Add("Tabela de turmas:\n");
            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)FontStyle.Italic);
            
            Paragraph paragrafo1 = new Paragraph(string.Empty, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, (int)FontStyle.Bold));
            paragrafo1.Alignment = Element.ALIGN_CENTER;
            string texto = System.DateTime.Now.ToString();
            paragrafo1.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)FontStyle.Italic);
            paragrafo1.Add(texto + "\n\n");

            //Criando uma tabela
            PdfPTable tabela = new PdfPTable(3); //Cria uma tabela com (X) colunas
            tabela.DefaultCell.FixedHeight = 20; //Define um tamanho fixo para as células

            tabela.AddCell(celula1);

            //Adicionando os cabeçalhos das colunas
            AddCell("ID", tabela, 5);
            AddCell("Turma", tabela, 40);
            AddCell("Horário", tabela, 40);

            DataTable dtTurmas = Banco.dql(queryDGV);
            for (int i = 0; i < dtTurmas.Rows.Count; i++)
            {
                tabela.AddCell(dtTurmas.Rows[i].Field<Int64>("ID").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<String>("Turma"));
                tabela.AddCell(dtTurmas.Rows[i].Field<String>("Horário"));
            }

            //Abre o arquivo pra fazer as alterações
            doc.Open(); 

            //Adicionando os elementos no arquivo
            doc.Add(paragrafo);
            doc.Add(paragrafo1);
            doc.Add(tabela);

            //Fecha o arquivo após as operações
            doc.Close();

            DialogResult res = MessageBox.Show("Deseja abrir o relatório?", "Relatório", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Globais.caminho + @"\turmas.pdf"); //Abre o arquivo pdf
            }
        }

        private void AddCell(string celtext, PdfPTable tabelaa, int size)
        {
            PdfPCell celula = new PdfPCell(new Phrase(celtext));
            PdfPTable tabela = tabelaa;
            celula.Colspan = 1;
            celula.FixedHeight = 30;
            celula.HorizontalAlignment = Element.ALIGN_CENTER;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            tabela.AddCell(celula);
        }

        private void VisualDGV()
        {
            dgv_turmas.Columns[0].Width = 40;
            dgv_turmas.Columns[1].Width = 120;
            dgv_turmas.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
