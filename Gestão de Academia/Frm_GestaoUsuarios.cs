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
    public partial class Frm_GestaoUsuarios : Form
    {
        public Frm_GestaoUsuarios()
        {
            InitializeComponent();
        }
        private void Frm_GestaoUsuarios_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNomes();
            VisualDGV();
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                DataTable dt;
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuarios(vid);
                tb_id.Text = dt.Rows[0].Field<long>("N_IDUSUARIO").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("T_NOMEUSUARIO").ToString();
                tb_username.Text = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                tb_senha.Text = dt.Rows[0].Field<string>("T_SENHAUSUARIO").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("T_STATUSUSUARIO").ToString();
                num_nivel.Text = dt.Rows[0].Field<Int32>("N_NIVELUSUARIO").ToString();
            }
        }

        private void btn_novoUsuario_Click(object sender, EventArgs e)
        {
            Frm_NovoUsuario frm_novoUsuario = new Frm_NovoUsuario();
            frm_novoUsuario.ShowDialog();
            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNomes();
            dgv_usuarios.Columns[0].Width = 85;
            dgv_usuarios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btn_salvarAlteracoes_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.id = Convert.ToInt32(tb_id.Text);
            u.nome = tb_nome.Text;
            u.username = tb_username.Text;
            u.senha = tb_senha.Text;
            u.status = cb_status.Text;
            u.nivel = Convert.ToInt32(Math.Round(num_nivel.Value, 0));
            Banco.AtualizarUsuario(u);
            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNomes();
            VisualDGV();
        }

        private void btn_excluirUsuario_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Usuario u = new Usuario();
                u.username = tb_username.Text;
                Banco.DeletaUsuario(u);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
            }
        }

        private void btn_fecharJanela_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void VisualDGV()
        {
            dgv_usuarios.Columns[0].Width = 50;
            dgv_usuarios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
