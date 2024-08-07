using System.Collections.Generic;
using System.Data.SqlClient;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.Data
{
    public class ServizioDao
    {
        private readonly string _connectionString;

        public ServizioDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Servizio> GetAllServizi()
        {
            var servizi = new List<Servizio>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Servizi";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servizio = new Servizio
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo"))
                            };

                            servizi.Add(servizio);
                        }
                    }
                }
            }

            return servizi;
        }
    }
}
