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
    public partial class Frm_SelecionarTurma : Form
    {
        Frm_Alunos frm_novoAluno;
        public Frm_SelecionarTurma(Frm_Alunos f)
        {
            InitializeComponent();
            this.frm_novoAluno = f;
        }

        private void Frm_SelecionarTurma_Load(object sender, EventArgs e)
        {
            string queryDGVTurma = String.Format($@"
            SELECT N_IDTURMA as '',
                   T_DSCTURMA as 'Matéria',
                   T_NOMEPROFESSOR as 'Professor',
                   T_DSCHORARIO as 'Horário',
                   N_MAXALUNOS as 'Vagas',
                   CASE 
                        WHEN T_STATUS = 'A' THEN 'Ativa'
                        WHEN T_STATUS = 'P' THEN 'Paralisada'
                        WHEN T_STATUS = 'C' THEN 'Cancelada'
                   END AS 'Status'
                            FROM tb_turmas
                            INNER JOIN tb_professores on tb_professores.N_IDPROFESSOR = tb_turmas.N_IDPROFESSOR
                            INNER JOIN tb_horarios on tb_horarios.N_IDHORARIO = tb_turmas.N_IDHORARIO");
            dgv_selecionarTurma.DataSource = Banco.dql(queryDGVTurma);            
            dgv_selecionarTurma.Columns[0].Visible = false;
            VisualDGV();
        }

        private void dgv_selecionarTurma_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            frm_novoAluno.tb_turma.Text = dgv_selecionarTurma.SelectedRows[0].Cells[1].Value.ToString();
            frm_novoAluno.tb_turma.Tag = dgv_selecionarTurma.SelectedRows[0].Cells[0].Value.ToString();
            Close();
        }

        private void VisualDGV()
        {
            dgv_selecionarTurma.Columns[1].Width = 90;
            dgv_selecionarTurma.Columns[2].Width = 300;
            dgv_selecionarTurma.Columns[3].Width = 100;
            dgv_selecionarTurma.Columns[4].Width = 50;
            dgv_selecionarTurma.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
