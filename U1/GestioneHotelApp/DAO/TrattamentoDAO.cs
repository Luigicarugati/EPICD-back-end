using System.Data.SqlClient;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.Data
{
    public class TrattamentoDao
    {
        private readonly string _connectionString;

        public TrattamentoDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Trattamento GetTrattamentoById(int id)
        {
            Trattamento trattamento = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Trattamenti WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trattamento = new Trattamento
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                TariffaSupplementare = reader.GetDecimal(reader.GetOrdinal("TariffaSupplementare"))
                            };
                        }
                    }
                }
            }

            return trattamento;
        }
    }
}
