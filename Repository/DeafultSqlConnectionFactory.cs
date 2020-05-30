using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=DESKTOP-EL3V5CT\\SQLEXPRESS2017;Database=HeroDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}