namespace Gestão_de_Academia
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nivel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_acesso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_button = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btn_alunos = new System.Windows.Forms.ToolStripMenuItem();
            this.novoAlunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_professores = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_horarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_turmas = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_login = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_logon = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_logoff = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_manutencao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_novoUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_gestaoDeUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_button)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.lb_nivel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lb_acesso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pb_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 518);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(784, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lb_nivel
            // 
            this.lb_nivel.AutoSize = true;
            this.lb_nivel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.lb_nivel.Location = new System.Drawing.Point(187, 17);
            this.lb_nivel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_nivel.Name = "lb_nivel";
            this.lb_nivel.Size = new System.Drawing.Size(15, 18);
            this.lb_nivel.TabIndex = 4;
            this.lb_nivel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(138, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nível:";
            // 
            // lb_acesso
            // 
            this.lb_acesso.AutoSize = true;
            this.lb_acesso.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.lb_acesso.Location = new System.Drawing.Point(100, 17);
            this.lb_acesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_acesso.Name = "lb_acesso";
            this.lb_acesso.Size = new System.Drawing.Size(32, 18);
            this.lb_acesso.TabIndex = 2;
            this.lb_acesso.Text = "------";
            this.lb_acesso.SizeChanged += new System.EventHandler(this.lb_acesso_SizeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário:";
            // 
            // pb_button
            // 
            this.pb_button.Location = new System.Drawing.Point(5, 11);
            this.pb_button.Margin = new System.Windows.Forms.Padding(4);
            this.pb_button.Name = "pb_button";
            this.pb_button.Size = new System.Drawing.Size(29, 29);
            this.pb_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_button.TabIndex = 0;
            this.pb_button.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_alunos,
            this.btn_professores,
            this.btn_horarios,
            this.btn_turmas,
            this.btn_login,
            this.btn_manutencao,
            this.btn_usuarios});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(784, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btn_alunos
            // 
            this.btn_alunos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoAlunoToolStripMenuItem,
            this.gestãoDeAlunosToolStripMenuItem});
            this.btn_alunos.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_alunos.Name = "btn_alunos";
            this.btn_alunos.Size = new System.Drawing.Size(58, 22);
            this.btn_alunos.Text = "Alunos";
            // 
            // novoAlunoToolStripMenuItem
            // 
            this.novoAlunoToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.novoAlunoToolStripMenuItem.Name = "novoAlunoToolStripMenuItem";
            this.novoAlunoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.novoAlunoToolStripMenuItem.Text = "Novo Aluno";
            this.novoAlunoToolStripMenuItem.Click += new System.EventHandler(this.btn_alunos1_Click);
            // 
            // gestãoDeAlunosToolStripMenuItem
            // 
            this.gestãoDeAlunosToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gestãoDeAlunosToolStripMenuItem.Name = "gestãoDeAlunosToolStripMenuItem";
            this.gestãoDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gestãoDeAlunosToolStripMenuItem.Text = "Gestão De Alunos";
            this.gestãoDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.gestãoDeAlunosToolStripMenuItem_Click);
            // 
            // btn_professores
            // 
            this.btn_professores.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_professores.Name = "btn_professores";
            this.btn_professores.Size = new System.Drawing.Size(84, 22);
            this.btn_professores.Text = "Professores";
            this.btn_professores.Click += new System.EventHandler(this.btn_professores1_Click);
            // 
            // btn_horarios
            // 
            this.btn_horarios.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_horarios.Name = "btn_horarios";
            this.btn_horarios.Size = new System.Drawing.Size(67, 22);
            this.btn_horarios.Text = "Horários";
            this.btn_horarios.Click += new System.EventHandler(this.horáriosToolStripMenuItem_Click);
            // 
            // btn_turmas
            // 
            this.btn_turmas.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_turmas.Name = "btn_turmas";
            this.btn_turmas.Size = new System.Drawing.Size(59, 22);
            this.btn_turmas.Text = "Turmas";
            this.btn_turmas.Click += new System.EventHandler(this.btn_turmas1_Click);
            // 
            // btn_login
            // 
            this.btn_login.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_login.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_logon,
            this.btn_logoff});
            this.btn_login.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(51, 22);
            this.btn_login.Text = "Login";
            // 
            // btn_logon
            // 
            this.btn_logon.Name = "btn_logon";
            this.btn_logon.Size = new System.Drawing.Size(111, 22);
            this.btn_logon.Text = "Logon";
            this.btn_logon.Click += new System.EventHandler(this.btn_logon_Click);
            // 
            // btn_logoff
            // 
            this.btn_logoff.Name = "btn_logoff";
            this.btn_logoff.Size = new System.Drawing.Size(111, 22);
            this.btn_logoff.Text = "Logoff";
            this.btn_logoff.Click += new System.EventHandler(this.btn_logoff_Click);
            // 
            // btn_manutencao
            // 
            this.btn_manutencao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.btn_manutencao.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_manutencao.Name = "btn_manutencao";
            this.btn_manutencao.Size = new System.Drawing.Size(88, 22);
            this.btn_manutencao.Text = "Manutenção";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "Banco de Dados";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btn_usuarios
            // 
            this.btn_usuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_novoUsuario,
            this.btn_gestaoDeUsuarios});
            this.btn_usuarios.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btn_usuarios.Name = "btn_usuarios";
            this.btn_usuarios.Size = new System.Drawing.Size(67, 22);
            this.btn_usuarios.Text = "Usuários";
            // 
            // btn_novoUsuario
            // 
            this.btn_novoUsuario.Name = "btn_novoUsuario";
            this.btn_novoUsuario.Size = new System.Drawing.Size(183, 22);
            this.btn_novoUsuario.Text = "Novo Usuário";
            this.btn_novoUsuario.Click += new System.EventHandler(this.btn_novoUsuario_Click_1);
            // 
            // btn_gestaoDeUsuarios
            // 
            this.btn_gestaoDeUsuarios.Name = "btn_gestaoDeUsuarios";
            this.btn_gestaoDeUsuarios.Size = new System.Drawing.Size(183, 22);
            this.btn_gestaoDeUsuarios.Text = "Gestão de Usuários";
            this.btn_gestaoDeUsuarios.Click += new System.EventHandler(this.btn_gestaoDeUsuarios_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Academia";
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_button)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lb_nivel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lb_acesso;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pb_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_alunos;
        private System.Windows.Forms.ToolStripMenuItem btn_professores;
        private System.Windows.Forms.ToolStripMenuItem btn_turmas;
        private System.Windows.Forms.ToolStripMenuItem btn_login;
        private System.Windows.Forms.ToolStripMenuItem btn_logon;
        private System.Windows.Forms.ToolStripMenuItem btn_logoff;
        private System.Windows.Forms.ToolStripMenuItem btn_manutencao;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btn_usuarios;
        private System.Windows.Forms.ToolStripMenuItem btn_novoUsuario;
        private System.Windows.Forms.ToolStripMenuItem btn_gestaoDeUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btn_horarios;
        private System.Windows.Forms.ToolStripMenuItem novoAlunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeAlunosToolStripMenuItem;
    }
}

