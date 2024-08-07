using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PoliziaApp.DAO
{
    public abstract class BaseDAO
    {
        protected string connectionString;

        public BaseDAO(IConfiguration configuration)
        {
            // Recupera la stringa di connessione dal file di configurazione
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
