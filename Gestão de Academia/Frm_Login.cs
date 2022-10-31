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
    public partial class Frm_Login : Form
    {
        Frm_Principal form1;
        DataTable dt = new DataTable();

        public Frm_Login(Frm_Principal f)
        {
            InitializeComponent();
            form1 = f;
        }
        
        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            string username = tb_Usuario.Text;
            string senha = tb_Senha.Text;

            if (username == "" || senha == "")
            {
                MessageBox.Show("Usuário ou senha inválidos");
                tb_Usuario.Focus();
                return;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE T_USERNAME='" + username + "' AND T_SENHAUSUARIO='" + senha + "'";
            dt = Banco.dql(sql);
            if (dt.Rows.Count == 1)
            {
                form1.lb_nivel.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lb_acesso.Text = dt.Rows[0].Field<string>("T_NOMEUSUARIO");
                form1.pb_button.Image = Properties.Resources.GREEN_BUTTON;
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int32>("N_NIVELUSUARIO").ToString());
                Globais.logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário não encontrado.");
            }
        }

        private void tb_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_logar_Click(sender, e);
            }
        }
    }
}