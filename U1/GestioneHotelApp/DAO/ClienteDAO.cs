using System.Collections.Generic;
using System.Data.SqlClient;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.Data
{
    public class ClienteDao
    {
        private readonly string _connectionString;

        public ClienteDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Cliente> GetAllClienti()
        {
            var clienti = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Clienti";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                CodiceFiscale = reader.GetString(reader.GetOrdinal("CodiceFiscale")),
                                Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Citta = reader.GetString(reader.GetOrdinal("Citta")),
                                Provincia = reader.GetString(reader.GetOrdinal("Provincia")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Cellulare = reader.GetString(reader.GetOrdinal("Cellulare"))
                            };
                            clienti.Add(cliente);
                        }
                    }
                }
            }

            return clienti;
        }
    }
}
