using System.Data.SqlClient;

namespace Infraestructure.Core.Repository
{
    public abstract class Repository
    {
        protected SqlConnection _connection;
        protected SqlTransaction _transaction;

        protected SqlCommand CrearComando(string query)
        {
            return new SqlCommand(query, _connection, _transaction);
        }
    }
}
