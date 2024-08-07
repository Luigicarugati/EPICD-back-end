using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PoliziaApp.Models;

namespace PoliziaApp.DAO
{
    public class TipoViolazioneDAO : BaseDAO
    {
        public TipoViolazioneDAO(IConfiguration configuration) : base(configuration) { }

        public List<TipoViolazione> GetAll()
        {
            List<TipoViolazione> tipiViolazioni = new List<TipoViolazione>();

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                 
                    string sql = "SELECT * FROM TIPI_VIOLAZIONI";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        while (reader.Read())
                        {
                            TipoViolazione tipoViolazione = new TipoViolazione
                            {
                                IdViolazione = reader.GetInt32(0),
                                Descrizione = reader.GetString(1)
                            };
                            tipiViolazioni.Add(tipoViolazione);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Errore: {ex.Message}");
                throw;
            }

            

            return tipiViolazioni;
        }
    }
}
