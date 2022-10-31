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
    public partial class Frm_Horarios : Form
    {
        public Frm_Horarios()
        {
            InitializeComponent();
        }

        private void Frm_Horarios_Load(object sender, EventArgs e)
        {
            string vquery = @"SELECT N_IDHORARIO as 'ID', T_DSCHORARIO as 'Horário' FROM tb_horarios ORDER BY T_DSCHORARIO";
            dgv_Horarios.DataSource = Banco.dql(vquery);
            VisualDGV();
        }

        private void dgv_Horarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv_Horarios.SelectedRows.Count > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string query = @"SELECT * FROM tb_horarios WHERE N_IDHORARIO=" + vid;
                dt = Banco.dml(query);
                tb_idHorario.Text = dt.Rows[0].Field<Int64>("N_IDHORARIO").ToString();
                mtb_dscHorario.Text = dt.Rows[0].Field<String>("T_DSCHORARIO").ToString();
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idHorario.Clear();
            mtb_dscHorario.Clear();
            mtb_dscHorario.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string query;
            if (tb_idHorario.Text == "")
            {
                query = @"INSERT INTO tb_horarios (T_DSCHORARIO) VALUES ('" + mtb_dscHorario.Text + "')";
            }
            else
            {
                query = @"UPDATE tb_horarios SET T_DSCHORARIO='" + mtb_dscHorario.Text + "' WHERE N_IDHORARIO="+tb_idHorario.Text;
            }
            
            Banco.dml(query);
            query = @"SELECT N_IDHORARIO as 'ID', T_DSCHORARIO as 'Horário' FROM tb_horarios ORDER BY T_DSCHORARIO";
            dgv_Horarios.DataSource = Banco.dql(query);
            VisualDGV();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            MessageBoxButtons yon = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Tem certeza que deseja excluir?","Excluir?", yon);
            if (result == DialogResult.Yes)
            {
                string query = @"DELETE FROM tb_horarios WHERE N_IDHORARIO=" + tb_idHorario.Text;
                Banco.dml(query);
                dgv_Horarios.Rows.Remove(dgv_Horarios.CurrentRow);
            }            
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisualDGV()
        {
            dgv_Horarios.Columns[0].Width = 40;
            dgv_Horarios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
