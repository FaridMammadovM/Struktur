using Npgsql;
using System.Data;

namespace Infrastructure.Persistence
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateDbConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection();
    }
}
