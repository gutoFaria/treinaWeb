using System;
using System.Data.SqlClient;

namespace Odbc
{
    public class AlteraEditora
    {
        public AlteraEditora()
        {
            try
            {
                using(SqlConnection connection = ConnectionFactory.CreateConnection())
                {
                    Editora e = new Editora();

                    Console.WriteLine("Digite o Id da editora que deseja mudar");
                    e.Id = Convert.ToInt64(Console.ReadLine());
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}