using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Gestão_de_Academia
{
    internal class Banco
    {
        private static SQLiteConnection conexao; //Variável de conexão

        private static SQLiteConnection ConexaoBanco() //Metodo para realizar a conexão com o banco
        {
            conexao = new SQLiteConnection("Data Source=" + Globais.caminhoBanco + Globais.nomeBanco);            
            conexao.Open(); //Abre a conexão            
            return conexao;
        }

        public static DataTable dql(string sql) //Função de SELECT genérica
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao);
                da.Fill(dt);
                vconexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable dml(string sql, string msgOK = null, string msgError = null) //Função de insert, delete e update genérica
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao);
                da.Fill(dt);
                vconexao.Close();
                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }
                return dt;
            }
            catch (Exception ex)
            {
                if (msgError != null)
                {
                    MessageBox.Show(msgError + "\n" + ex.Message);
                }
                throw ex;
            }
        }

        //Funções do FORM Frm_GestaoUsuarios
        public static DataTable ObterUsuariosIdNomes()
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = "SELECT N_IDUSUARIO as 'ID',T_NOMEUSUARIO as 'Nome' FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao); //(o comando que queremos usar, a conexao)
                da.Fill(dt);
                vconexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//FIM Funções do FORM Frm_GestaoUsuarios

        public static DataTable ObterDadosUsuarios(string id)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios WHERE N_IDUSUARIO =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao); //(o comando que queremos usar, a conexao)
                da.Fill(dt);
                vconexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void NovoUsuario(Usuario u)
        {
            if (existeUsuario(u))
            {
                MessageBox.Show("Username já cadastrado.");
                return;
            }
            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (T_NOMEUSUARIO, T_USERNAME, T_SENHAUSUARIO, T_STATUSUSUARIO, N_NIVELUSUARIO) VALUES (@nome, @username, @senha, @status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário inserido com sucesso!");
                vconexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao cadastrar novo usuário.");
            }

        }

        // Verifica se o usuário cadastrado já existe no Banco de Dados
        public static bool existeUsuario(Usuario u)
        {
            bool res;
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;

            var vconexao = ConexaoBanco();
            var cmd = vconexao.CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME = '" + u.username + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vconexao);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vconexao.Close();
            return res;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>//
        public static void AtualizarUsuario(Usuario u)
        {
            SQLiteDataAdapter da;

            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = "UPDATE tb_usuarios SET T_NOMEUSUARIO = '" + u.nome + "', T_USERNAME = '" + u.username + "', T_SENHAUSUARIO = '" + u.senha + "', T_STATUSUSUARIO = '" + u.status + "', N_NIVELUSUARIO = '" + u.nivel + "' WHERE N_IDUSUARIO = '" + u.id + "'";
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao);
                cmd.ExecuteNonQuery();
                vconexao.Close();
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>//

        public static void DeletaUsuario(Usuario u)
        {
            SQLiteDataAdapter da;

            try
            {
                var vconexao = ConexaoBanco();
                var cmd = vconexao.CreateCommand();
                cmd.CommandText = "DELETE FROM tb_usuarios WHERE T_USERNAME = '" + u.username + "'";
                da = new SQLiteDataAdapter(cmd.CommandText, vconexao);
                cmd.ExecuteNonQuery();
                vconexao.Close();
                MessageBox.Show("Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void AtualizarDGV(DataGridView dgv ,string query)
        {
            dgv.DataSource = Banco.dql(query);
        }
    }
}
