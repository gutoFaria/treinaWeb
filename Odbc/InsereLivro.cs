using System.Data.SqlClient;
using System;

namespace Odbc
{
    public class InsereLivro
    {
        public InsereLivro()
        {
            string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=livraria;Data Source=DESKTOP-96580IO\SQLEXPRESS01;";
            Livros l = new Livros();

            Console.Write("Digite o nome do Livro:");
            l.Nome = Console.ReadLine();

            Console.Write("Digite o Id  da Editora:");
            l.EditoraId = Int32.Parse(Console.ReadLine());

            try
            {
                string sql = @"INSERT INTO Livros (Nome,EditoraId) OUTPUT INSERTED.id VALUES(@Nome,@EditoraId)";
                using(SqlConnection conexao = new SqlConnection(stringDeConexao))
                {
                    SqlCommand  command = new SqlCommand(sql,conexao);

                    command.Parameters.AddWithValue(@"Nome",l.Nome);
                    command.Parameters.AddWithValue(@"EditoraId",l.EditoraId);

                    conexao.Open();
                    l.Id = command.ExecuteScalar() as long?;
                    Console.WriteLine("Livro cadastrado com Id:" + l.Id);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Falha ao cadastrar livro");
            }
        }
    }
}