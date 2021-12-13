using System.Data.SqlClient;
using System;

namespace Odbc
{
    public class CriaBaseDeDadosLivraria
    {
        public void CriaConexao()
        {
            string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Data Source=DESKTOP-96580IO\SQLEXPRESS01;";
            using(SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();
                try
                {
                    string sql = @"IF EXISTS( SELECT name FROM master.dbo.sysdatabases WHERE name = 'livraria ')DROP DATABASE livraria ";
                    SqlCommand command = new SqlCommand (sql , conexao );
                    command.ExecuteNonQuery ();

                    sql = @" CREATE DATABASE livraria ";
                    command = new SqlCommand (sql , conexao );
                    command . ExecuteNonQuery ();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao conectar com a base dados" + e.Message);
                }

            }
        }
        
    }

}