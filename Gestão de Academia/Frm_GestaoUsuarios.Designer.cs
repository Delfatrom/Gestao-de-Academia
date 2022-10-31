namespace Gestão_de_Academia
{
    partial class Frm_GestaoUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_usuarios = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_fecharJanela = new System.Windows.Forms.Button();
            this.btn_excluirUsuario = new System.Windows.Forms.Button();
            this.btn_salvarAlteracoes = new System.Windows.Forms.Button();
            this.btn_novoUsuario = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.num_nivel = new System.Windows.Forms.NumericUpDown();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelbale = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_senha = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_nivel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_usuarios
            // 
            this.dgv_usuarios.AllowUserToAddRows = false;
            this.dgv_usuarios.AllowUserToDeleteRows = false;
            this.dgv_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_usuarios.EnableHeadersVisualStyles = false;
            this.dgv_usuarios.Location = new System.Drawing.Point(270, 5);
            this.dgv_usuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_usuarios.MultiSelect = false;
            this.dgv_usuarios.Name = "dgv_usuarios";
            this.dgv_usuarios.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_usuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_usuarios.RowHeadersVisible = false;
            this.dgv_usuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_usuarios.Size = new System.Drawing.Size(383, 242);
            this.dgv_usuarios.TabIndex = 39;
            this.dgv_usuarios.SelectionChanged += new System.EventHandler(this.dgv_usuarios_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_fecharJanela);
            this.panel1.Controls.Add(this.btn_excluirUsuario);
            this.panel1.Controls.Add(this.btn_salvarAlteracoes);
            this.panel1.Controls.Add(this.btn_novoUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 39);
            this.panel1.TabIndex = 38;
            // 
            // btn_fecharJanela
            // 
            this.btn_fecharJanela.Location = new System.Drawing.Point(594, 9);
            this.btn_fecharJanela.Margin = new System.Windows.Forms.Padding(4);
            this.btn_fecharJanela.Name = "btn_fecharJanela";
            this.btn_fecharJanela.Size = new System.Drawing.Size(59, 26);
            this.btn_fecharJanela.TabIndex = 0;
            this.btn_fecharJanela.Text = "Fechar";
            this.btn_fecharJanela.UseVisualStyleBackColor = true;
            this.btn_fecharJanela.Click += new System.EventHandler(this.btn_fecharJanela_Click);
            // 
            // btn_excluirUsuario
            // 
            this.btn_excluirUsuario.Location = new System.Drawing.Point(270, 10);
            this.btn_excluirUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btn_excluirUsuario.Name = "btn_excluirUsuario";
            this.btn_excluirUsuario.Size = new System.Drawing.Size(126, 26);
            this.btn_excluirUsuario.TabIndex = 0;
            this.btn_excluirUsuario.Text = "Excluir usuário";
            this.btn_excluirUsuario.UseVisualStyleBackColor = true;
            this.btn_excluirUsuario.Click += new System.EventHandler(this.btn_excluirUsuario_Click);
            // 
            // btn_salvarAlteracoes
            // 
            this.btn_salvarAlteracoes.Location = new System.Drawing.Point(136, 10);
            this.btn_salvarAlteracoes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_salvarAlteracoes.Name = "btn_salvarAlteracoes";
            this.btn_salvarAlteracoes.Size = new System.Drawing.Size(126, 26);
            this.btn_salvarAlteracoes.TabIndex = 0;
            this.btn_salvarAlteracoes.Text = "Salvar alterações";
            this.btn_salvarAlteracoes.UseVisualStyleBackColor = true;
            this.btn_salvarAlteracoes.Click += new System.EventHandler(this.btn_salvarAlteracoes_Click);
            // 
            // btn_novoUsuario
            // 
            this.btn_novoUsuario.Location = new System.Drawing.Point(4, 10);
            this.btn_novoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btn_novoUsuario.Name = "btn_novoUsuario";
            this.btn_novoUsuario.Size = new System.Drawing.Size(126, 26);
            this.btn_novoUsuario.TabIndex = 0;
            this.btn_novoUsuario.Text = "Novo usuário";
            this.btn_novoUsuario.UseVisualStyleBackColor = true;
            this.btn_novoUsuario.Click += new System.EventHandler(this.btn_novoUsuario_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 37;
            this.label5.Text = "Nível:";
            // 
            // num_nivel
            // 
            this.num_nivel.Location = new System.Drawing.Point(190, 203);
            this.num_nivel.Margin = new System.Windows.Forms.Padding(4);
            this.num_nivel.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_nivel.Name = "num_nivel";
            this.num_nivel.Size = new System.Drawing.Size(63, 21);
            this.num_nivel.TabIndex = 36;
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cb_status.Location = new System.Drawing.Point(19, 205);
            this.cb_status.Margin = new System.Windows.Forms.Padding(4);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(116, 26);
            this.cb_status.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Senha:";
            // 
            // labelbale
            // 
            this.labelbale.AutoSize = true;
            this.labelbale.Location = new System.Drawing.Point(19, 11);
            this.labelbale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelbale.Name = "labelbale";
            this.labelbale.Size = new System.Drawing.Size(23, 18);
            this.labelbale.TabIndex = 33;
            this.labelbale.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Username:";
            // 
            // tb_senha
            // 
            this.tb_senha.Location = new System.Drawing.Point(144, 146);
            this.tb_senha.Margin = new System.Windows.Forms.Padding(4);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.Size = new System.Drawing.Size(118, 21);
            this.tb_senha.TabIndex = 28;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(19, 33);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(117, 21);
            this.tb_id.TabIndex = 30;
            this.tb_id.TabStop = false;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(19, 146);
            this.tb_username.Margin = new System.Windows.Forms.Padding(4);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(117, 21);
            this.tb_username.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nome:";
            // 
            // tb_nome
            // 
            this.tb_nome.Location = new System.Drawing.Point(19, 85);
            this.tb_nome.Margin = new System.Windows.Forms.Padding(4);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(243, 21);
            this.tb_nome.TabIndex = 23;
            // 
            // Frm_GestaoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 291);
            this.Controls.Add(this.dgv_usuarios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num_nivel);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelbale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_senha);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_nome);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_GestaoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Usuários";
            this.Load += new System.EventHandler(this.Frm_GestaoUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_nivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_usuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_fecharJanela;
        private System.Windows.Forms.Button btn_excluirUsuario;
        private System.Windows.Forms.Button btn_salvarAlteracoes;
        private System.Windows.Forms.Button btn_novoUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_nivel;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelbale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_senha;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nome;
    }
}