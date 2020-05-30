using System.Data;

namespace Repository
{
    public interface IConnectionFactory
    {
         IDbConnection Connection();
    }
}