using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Streamish.Repositories
{
    public abstract class BaseRepository // "Abstract" It indicates that our `BaseRepository` class cannot be directly instantiated, but can ONLY be used by inheritance.
    {
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection Connection // This is marked 'Protected' so only the child classes can have access to it. No others.
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
