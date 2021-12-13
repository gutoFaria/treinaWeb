using System;
using System.Data.SqlClient;
using System.Text;

namespace Odbc
{
    public class ConnectionFactory
    {
       public static SqlConnection CreateConnection()
       {
           string integratedSecurity = @"SSPI";
           string persistSecurityInfo = @"False";
           string InitialCatalog = @"livraria";
           string dataSource = @"DESKTOP-96580IO";
           string servidor = @"\SQLEXPRESS01;";

           StringBuilder connectionString = new StringBuilder();
           connectionString.Append("Integrated Security=");
           connectionString.Append(integratedSecurity);
           connectionString.Append(";Persist Security Info=");
           connectionString.Append(persistSecurityInfo);
           connectionString.Append(";Initial Catalog=");
           connectionString.Append(InitialCatalog);
           connectionString.Append(";Data Source=");
           connectionString.Append(dataSource);
           connectionString.Append(servidor);

           return new SqlConnection(connectionString.ToString());
       }
    }
}