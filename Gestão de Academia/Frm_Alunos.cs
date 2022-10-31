using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;        //Para trabalhar com arquivos

namespace Gestão_de_Academia
{
    public partial class Frm_Alunos : Form
    {
        string origemCompleto = "";
        string foto = "";
        string pastaDestino = Globais.caminhoFotos;
        string destinoCompleto = "";

        public Frm_Alunos()
        {
            InitializeComponent();
        }

        private void Frm_Alunos_Load(object sender, EventArgs e)
        {
            tb_nome.Focus();
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A", "Ativa"); status.Add("P", "Paralisada"); status.Add("C", "Cancelada");
            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_nome.Clear();
            mtb_telefone.Clear();
            cb_status.SelectedIndex = -1;
            tb_turma.Clear();
            tb_plano.Clear();
            tb_nome.Focus();
            pb_foto.Image = null;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if(destinoCompleto == "")
            {
                if (MessageBox.Show("Sem foto selecionada, deseja continuar?", "Error", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            if (destinoCompleto != "")
            {
                File.Copy(origemCompleto, destinoCompleto, true);
                if (File.Exists(destinoCompleto))
                {
                    pb_foto.ImageLocation = destinoCompleto;
                }
                else
                {
                    if (MessageBox.Show("Erro ao localizar foto, deseja continuar?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        return;
                    }                    
                }
            }

            string queryInsertAluno = String.Format($@"
                INSERT INTO tb_alunos (T_NOMEALUNO,T_TELEFONE,T_STATUS,N_IDTURMA,T_FOTO)
                        VALUES ('{tb_nome.Text}','{mtb_telefone.Text}','{cb_status.SelectedValue}',{tb_turma.Tag},'{destinoCompleto}')");
            Banco.dml(queryInsertAluno);
            MessageBox.Show("Novo aluno inserido");
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_selTurma_Click(object sender, EventArgs e)
        {
            Frm_SelecionarTurma frm_selecionarTurma = new Frm_SelecionarTurma(this);
            frm_selecionarTurma.ShowDialog();
        }

        private void btn_addFoto_Click(object sender, EventArgs e)
        {
            origemCompleto = "";
            foto = "";
            pastaDestino = Globais.caminhoFotos;
            destinoCompleto = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Copia o caminho do arquivo mais o nome dele para uma string (origemCompleto)
                origemCompleto = openFileDialog1.FileName;
                //Copia somente o nome do arquivo e sua extenção
                foto = openFileDialog1.SafeFileName;
                //O caminho que ele vai ficar mais o nome do arquivo
                destinoCompleto = pastaDestino + foto;
            }
            if (File.Exists(destinoCompleto))
            {
                //Verifica se o usuário deseja realmente excluir
                if (MessageBox.Show("Arquivo já existe, deseja substituir?", "Substituir", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            //Verifica se algum arquivo foi selecionado
            if (File.Exists(origemCompleto))
            {
                //Copia o arquivo da origem pro destino (true é a chave pra ativar a copia)
                System.IO.File.Copy(origemCompleto, destinoCompleto, true); 
            }
            //Se ele foi copiado mesmo faça:
            if (File.Exists(destinoCompleto))
            {
                //Mostre ele no meu pictureBox
                pb_foto.ImageLocation = destinoCompleto;
            }
            else
            {
                MessageBox.Show("Arquivo não copiado.", "Error");

            }
        }
    }
}
