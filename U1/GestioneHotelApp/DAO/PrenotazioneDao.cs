using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.DAO
{
    public class PrenotazioneDao
    {
        private readonly string _connectionString;

        public PrenotazioneDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Prenotazione> GetAllPrenotazioni()
        {
            var prenotazioni = new List<Prenotazione>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT p.*, 
                           c.Cognome AS CognomeCliente, 
                           c.Nome AS NomeCliente, 
                           cam.Descrizione AS DescrizioneCamera, 
                           cam.Tipologia AS TipologiaCamera, 
                           t.Descrizione AS DescrizioneTrattamento
                    FROM Prenotazioni p
                    JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
                    JOIN Camere cam ON p.NumeroCamera = cam.Numero
                    JOIN Trattamenti t ON p.TrattamentoId = t.Id", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prenotazione = new Prenotazione
                    {
                        Id = (int)reader["Id"],
                        CodiceFiscaleCliente = reader["CodiceFiscaleCliente"].ToString(),
                        NumeroCamera = (int)reader["NumeroCamera"],
                        DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                        NumeroProgressivoAnno = (int)reader["NumeroProgressivoAnno"],
                        Anno = (int)reader["Anno"],
                        Dal = (DateTime)reader["Dal"],
                        Al = (DateTime)reader["Al"],
                        CaparraConfirmatoria = (decimal)reader["CaparraConfirmatoria"],
                        TariffaApplicata = (decimal)reader["TariffaApplicata"],
                        TrattamentoId = (int)reader["TrattamentoId"],
                        Cliente = new Cliente
                        {
                            Cognome = reader["CognomeCliente"].ToString(),
                            Nome = reader["NomeCliente"].ToString()
                        },
                        Camera = new Camera
                        {
                            Descrizione = reader["DescrizioneCamera"].ToString(),
                            Tipologia = reader["TipologiaCamera"].ToString()
                        },
                        Trattamento = new Trattamento
                        {
                            Descrizione = reader["DescrizioneTrattamento"].ToString()
                        }
                    };
                    prenotazioni.Add(prenotazione);
                }
            }

            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioniByNomeCognome(string nome, string cognome)
        {
            var prenotazioni = new List<Prenotazione>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT p.*, 
                           c.Cognome AS CognomeCliente, 
                           c.Nome AS NomeCliente, 
                           cam.Descrizione AS DescrizioneCamera, 
                           cam.Tipologia AS TipologiaCamera, 
                           t.Descrizione AS DescrizioneTrattamento
                    FROM Prenotazioni p
                    JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
                    JOIN Camere cam ON p.NumeroCamera = cam.Numero
                    JOIN Trattamenti t ON p.TrattamentoId = t.Id
                    WHERE c.Nome = @Nome AND c.Cognome = @Cognome", conn);

                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Cognome", cognome);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prenotazione = new Prenotazione
                    {
                        Id = (int)reader["Id"],
                        CodiceFiscaleCliente = reader["CodiceFiscaleCliente"].ToString(),
                        NumeroCamera = (int)reader["NumeroCamera"],
                        DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                        NumeroProgressivoAnno = (int)reader["NumeroProgressivoAnno"],
                        Anno = (int)reader["Anno"],
                        Dal = (DateTime)reader["Dal"],
                        Al = (DateTime)reader["Al"],
                        CaparraConfirmatoria = (decimal)reader["CaparraConfirmatoria"],
                        TariffaApplicata = (decimal)reader["TariffaApplicata"],
                        TrattamentoId = (int)reader["TrattamentoId"],
                        Cliente = new Cliente
                        {
                            Cognome = reader["CognomeCliente"].ToString(),
                            Nome = reader["NomeCliente"].ToString()
                        },
                        Camera = new Camera
                        {
                            Descrizione = reader["DescrizioneCamera"].ToString(),
                            Tipologia = reader["TipologiaCamera"].ToString()
                        },
                        Trattamento = new Trattamento
                        {
                            Descrizione = reader["DescrizioneTrattamento"].ToString()
                        }
                    };
                    prenotazioni.Add(prenotazione);
                }
            }

            return prenotazioni;
        }
    }
}