using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_de_Academia
{
    public partial class Frm_Professores : Form
    {
        public Frm_Professores()
        {
            InitializeComponent();
        }
        private void Frm_Professores_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "SELECT N_IDPROFESSOR AS 'ID', T_NOMEPROFESSOR AS 'Nome', T_TELEFONE AS 'Telefone' FROM tb_professores ORDER BY T_NOMEPROFESSOR";
            dt = Banco.dql(query);
            dgv_professores.DataSource = dt;
            VisualDGV();
        }

        private void dgv_professores_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv_professores.SelectedRows.Count > 0)
            {
                DataTable dt = new DataTable();
                string pid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string query = "SELECT * FROM tb_professores WHERE N_IDPROFESSOR=" + pid + " ORDER BY T_NOMEPROFESSOR";
                dt = Banco.dml(query);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString();
                tb_professor.Text = dt.Rows[0].Field<String>("T_NOMEPROFESSOR").ToString();
                mtb_telefone.Text = dt.Rows[0].Field<String>("T_TELEFONE").ToString();
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_id.Clear();
            tb_professor.Clear();
            mtb_telefone.Clear();
            tb_professor.Focus();            
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string query;
            if (tb_id.Text == "")
            {
                query = $@"INSERT INTO tb_professores (T_NOMEPROFESSOR,T_TELEFONE) VALUES ('{tb_professor.Text}','{mtb_telefone.Text}')";
            }
            else
            {
                query = $@"UPDATE tb_professores SET T_NOMEPROFESSOR='{tb_professor.Text}',T_TELEFONE='{mtb_telefone.Text}' WHERE N_IDPROFESSOR={tb_id.Text}";
            }
            Banco.dml(query);
            query = "SELECT N_IDPROFESSOR AS 'ID', T_NOMEPROFESSOR AS 'Nome', T_TELEFONE AS 'Telefone' FROM tb_professores";
            dgv_professores.DataSource = Banco.dml(query);
            VisualDGV();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseja realmente excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {   
                string query = $@"DELETE FROM tb_professores WHERE N_IDPROFESSOR={tb_id.Text}";
                Banco.dml(query);
                query = "SELECT N_IDPROFESSOR AS 'ID', T_NOMEPROFESSOR AS 'Nome', T_TELEFONE AS 'Telefone' FROM tb_professores";
                dgv_professores.DataSource = Banco.dml(query);
                VisualDGV();
            }            
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisualDGV()
        {
            dgv_professores.Columns[0].Width = 40;
            dgv_professores.Columns[1].Width = 380;
            dgv_professores.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
