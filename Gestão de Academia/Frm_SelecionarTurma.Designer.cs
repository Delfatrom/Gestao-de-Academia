namespace Gestão_de_Academia
{
    partial class Frm_SelecionarTurma
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
            this.dgv_selecionarTurma = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_selecionarTurma)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_selecionarTurma
            // 
            this.dgv_selecionarTurma.AllowUserToAddRows = false;
            this.dgv_selecionarTurma.AllowUserToDeleteRows = false;
            this.dgv_selecionarTurma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_selecionarTurma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_selecionarTurma.Location = new System.Drawing.Point(0, 0);
            this.dgv_selecionarTurma.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_selecionarTurma.MultiSelect = false;
            this.dgv_selecionarTurma.Name = "dgv_selecionarTurma";
            this.dgv_selecionarTurma.ReadOnly = true;
            this.dgv_selecionarTurma.RowHeadersVisible = false;
            this.dgv_selecionarTurma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_selecionarTurma.Size = new System.Drawing.Size(804, 526);
            this.dgv_selecionarTurma.TabIndex = 0;
            this.dgv_selecionarTurma.DoubleClick += new System.EventHandler(this.dgv_selecionarTurma_DoubleClick);
            // 
            // Frm_SelecionarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 526);
            this.Controls.Add(this.dgv_selecionarTurma);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_SelecionarTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Turma";
            this.Load += new System.EventHandler(this.Frm_SelecionarTurma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_selecionarTurma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_selecionarTurma;
    }
}