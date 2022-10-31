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
    public partial class Frm_Principal : Form
    {
        Frm_Alunos frm_alunos = new Frm_Alunos();
        Frm_Professores frm_professores = new Frm_Professores();
        Frm_Turmas frm_turmas = new Frm_Turmas();
        Frm_Horarios frm_horarios = new Frm_Horarios();
        Frm_GestaoAlunos frm_gestaoAlunos = new Frm_GestaoAlunos();

        public Frm_Principal()
        {
            InitializeComponent();
            Frm_Login frm_login = new Frm_Login(this);
            frm_login.ShowDialog();
            VerificaLogin();
        }

        private void btn_alunos1_Click(object sender, EventArgs e)
        {
            frm_alunos.ShowDialog();
        }

        private void btn_professores1_Click(object sender, EventArgs e)
        {
            abreForm(0, frm_professores);
        }

        private void btn_turmas1_Click(object sender, EventArgs e)
        {
            abreForm(0, frm_turmas);
        }

        private void btn_logon_Click(object sender, EventArgs e)
        {
            Frm_Login frm_login = new Frm_Login(this);
            frm_login.ShowDialog();
            VerificaLogin();
        }

        private void btn_logoff_Click(object sender, EventArgs e)
        {
            lb_nivel.Text = "0";
            lb_acesso.Text = "------";
            pb_button.Image = Properties.Resources.RED_BUTTON;
            Globais.nivel = 0;
            Globais.logado = false;
            VerificaLogin();
        }

        private void VerificaLogin()
        {
            if (Globais.logado == true)
            {
                btn_alunos.Enabled = true;
                btn_professores.Enabled = true;
                btn_horarios.Enabled = true;
                btn_turmas.Enabled = true;
                if (Globais.nivel >= 2)
                {
                    btn_manutencao.Enabled = true;
                    btn_usuarios.Enabled = true;
                }
                else
                {
                    btn_manutencao.Enabled = false;
                    btn_usuarios.Enabled = false;
                }
            }
            else
            {
                btn_alunos.Enabled = false;
                btn_professores.Enabled = false;
                btn_horarios.Enabled = false;
                btn_turmas.Enabled = false;
                btn_manutencao.Enabled = false;
                btn_usuarios.Enabled = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Propriedade não implementada.","Em construção");
        }

        private void btn_novoUsuario_Click_1(object sender, EventArgs e)
        {
            Frm_NovoUsuario frm_novoUsuario = new Frm_NovoUsuario();
            abreForm(Globais.nivel, frm_novoUsuario);            
        }

        private void btn_gestaoDeUsuarios_Click(object sender, EventArgs e)
        {
            Frm_GestaoUsuarios frm_gestaoUsuarios = new Frm_GestaoUsuarios();
            abreForm(Globais.nivel, frm_gestaoUsuarios);
        }

        private void lb_acesso_SizeChanged(object sender, EventArgs e)
        {
            int t = lb_acesso.Size.Width;
            label3.Location = new System.Drawing.Point(lb_acesso.Location.X + t, lb_acesso.Location.Y);
            lb_nivel.Location = new System.Drawing.Point(label3.Location.X + 42, lb_acesso.Location.Y);
        }

        private void horáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abreForm(Globais.nivel , frm_horarios);            
        }

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= nivel)
                {
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado!");
            }
        }

        private void gestãoDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_gestaoAlunos.ShowDialog();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.img_Frm_Principal;
            menuStrip1.BackColor = System.Drawing.Color.Gold;
        }
    }
}
