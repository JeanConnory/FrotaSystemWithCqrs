using Microsoft.Data.SqlClient;
using System.Data;

namespace FrotaApp.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Server=CONNORYLAPTOP\\OLTP;Database=banco_frota;User Id=sa;Password=Jmc.123;TrustServerCertificate=True;");
        }
    }
}
