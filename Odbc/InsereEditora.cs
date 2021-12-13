using System.Data.SqlClient;
using System;
namespace Odbc
{
    public class InsereEditora
    {
        public InsereEditora()
        {
            string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=livraria;Data Source=DESKTOP-96580IO\SQLEXPRESS01;";
            Editora e = new Editora();

            Console.Write("Digite o nome da Editora:");
            e.Nome = Console.ReadLine();

            Console.Write("Digite o Email da Editora:");
            e.Email = Console.ReadLine();

            string sql = @"INSERT INTO Editoras (Nome,Email) OUTPUT INSERTED.id VALUES(@Nome, @Email)";
            using(SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand  command = new SqlCommand(sql,conexao);

                //pega os caracteres especiais
                command.Parameters.AddWithValue(@"Nome",e.Nome);
                command.Parameters.AddWithValue(@"Email",e.Email);

                conexao.Open();
                e.Id = command.ExecuteScalar() as long?;
                Console.WriteLine("Editora cadastrada com Id:" + e.Id);
            }
        }
    }
}