using System.Collections.Generic;
using System.Data.SqlClient;

namespace Odbc
{
    public class ListaLivros
    {
        public ListaLivros()
        {
            
             try
                {
                    using(SqlConnection connection = ConnectionFactory.CreateConnection())
                    {
                        string sql = "SELECT * FROM Livros";
                        SqlCommand command = new SqlCommand(sql,connection);
                        connection.Open();

                        SqlDataReader result = command.ExecuteReader();//faz a leitura
                        List<Livros> lista = new List<Livros>();

                        while(result.Read())
                        {
                            Livros L = new Livros();

                            L.Id = result["Id"] as long?;
                            L.Nome = result["Nome"] as string;
                            L.EditoraId = result["EditoraId"] as int?;

                            lista.Add(L);
                        }

                        foreach (Livros L in lista)
                        {
                            Console.WriteLine("{0} : {1} - {2}\n",L.Id,L.Nome,L.EditoraId);
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
