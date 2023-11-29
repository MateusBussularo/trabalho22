using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho2
{
    internal class UsuarioDAO
    {
        public List<Usuario> SelectUsuario()
        {
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro1";
             
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {

                    Usuario objeto = new Usuario(


                    (int)dr["prontuario"],
                    (string)dr["CPF"],
                    (string)dr["senha"]

                    );
                    usuarios.Add(objeto);
                }
                dr.Close();

                return usuarios;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }
        public void UpdateUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Cadastro1 SET 
            CPF= @cpf, 
            senha= @senha
            WHERE Prontuario=@prontuario";

            sqlCommand.Parameters.AddWithValue("@cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@prontuario", usuario.prontuario);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("EDITADO COM SUCESSO!",
               "AVISO",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        public void InsertUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Cadastro1 VALUES 
            (@CPF, @senha)";

            sqlCommand.Parameters.AddWithValue("@CPF", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("CADASTRADO COM SUCESSO",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void DeletUsuario(int Id)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Cadastro1 WHERE prontuario = @prontuario";
            sqlCommand.Parameters.AddWithValue("@prontuario", Id);
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public bool Loginuser(Usuario login)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"SELECT COUNT(*) FROM Cadastro1 WHERE CPF=@cpf AND senha=@senha";

            sqlCommand.Parameters.AddWithValue("@cpf", login.Cpf);
            sqlCommand.Parameters.AddWithValue("@senha", login.Senha);

            int count = (int)sqlCommand.ExecuteScalar();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
