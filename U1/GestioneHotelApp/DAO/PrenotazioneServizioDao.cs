using System.Collections.Generic;
using System.Data.SqlClient;
using GestioneHotelApp.Models;
using GestioneHotelApp.DAO;
using GestioneHotelApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace GestioneHotelApp.Data
{
    public class PrenotazioneServizioDao
    {
        private readonly string _connectionString;

        public PrenotazioneServizioDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PrenotazioneServizio> GetAllPrenotazioniServizi()
        {
            var prenotazioniServizi = new List<PrenotazioneServizio>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM PrenotazioniServizi";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazioneServizio = new PrenotazioneServizio
                            {
                                IdPrenotazione = reader.GetInt32(reader.GetOrdinal("IdPrenotazione")),
                                ServizioId = reader.GetInt32(reader.GetOrdinal("ServizioId"))
                            };

                            prenotazioniServizi.Add(prenotazioneServizio);
                        }
                    }
                }
            }

            return prenotazioniServizi;
        }
    }
}
