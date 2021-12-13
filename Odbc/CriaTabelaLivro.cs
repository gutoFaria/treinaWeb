using System.Data.SqlClient;

namespace Odbc
{
    public class CriaTabelaLivro
    {
        public void CriaLivro()
        {
            string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=livraria;Data Source=DESKTOP-96580IO\SQLEXPRESS01;";
            using(SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();
                try
                {
                    string sql = " CREATE TABLE Livros (" +
                                "id BIGINT IDENTITY (1 ,1) ," +
                                " nome VARCHAR (255) NOT NULL ," +
                                " editoraId BIGINT  NOT NULL ," +
                                " CONSTRAINT PK_Livros PRIMARY KEY CLUSTERED (id asc )" +
                                ")";
                    SqlCommand command = new SqlCommand (sql , conexao );
                    command . ExecuteNonQuery ();
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro ao criar tabela livro");
                }
            }
        }
    }
}