using System.Data.SqlClient;
using System.Collections.Generic;
namespace Odbc
{
    public class ListaEditoras
    {
        public ListaEditoras()
        {
            string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=livraria;Data Source=DESKTOP-96580IO\SQLEXPRESS01;";

            try
            {
                using(SqlConnection connection = new SqlConnection(stringDeConexao))
                {
                    string sql = "SELECT * FROM Editoras";
                    SqlCommand command = new SqlCommand(sql,connection);
                    connection.Open();

                    SqlDataReader result = command.ExecuteReader();//faz a leitura
                    List<Editora> lista = new List<Editora>();

                    while(result.Read())
                    {
                        Editora e = new Editora();

                        e.Id = result["Id"] as long?;
                        e.Nome = result["Nome"] as string;
                        e.Email = result["Email"] as string;

                        lista.Add(e);
                    }

                    foreach (Editora e in lista)
                    {
                        Console.WriteLine("{0} : {1} - {2}\n",e.Id,e.Nome,e.Email);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao fazer a conexao ou leitura dos dados");
            }
        }
    }
}