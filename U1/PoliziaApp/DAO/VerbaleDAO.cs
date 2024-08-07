using System.Collections.Generic;
using System.Data.SqlClient;
using PoliziaApp.Models;
using Microsoft.Extensions.Configuration;

namespace PoliziaApp.DAO
{
    public class VerbaleDAO : BaseDAO
    {
        public VerbaleDAO(IConfiguration configuration) : base(configuration) { }

        public List<Verbale> GetAll()
        {
            List<Verbale> verbali = new List<Verbale>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM VERBALI";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Verbale verbale = new Verbale
                        {
                            IdVerbale = (int)reader["IdVerbale"],
                            IdAnagrafica = (int)reader["IdAnagrafica"],
                            IdViolazione = (int)reader["IdViolazione"],
                            DataViolazione = (DateTime)reader["DataViolazione"],
                            IndirizzoViolazione = (string)reader["IndirizzoViolazione"],
                            Nominativo_Agente = (string)reader["Nominativo_Agente"],
                            DataTrascrizioneVerbale = (DateTime)reader["DataTrascrizioneVerbale"],
                            Importo = (decimal)reader["Importo"],
                            DecurtamentoPunti = reader["DecurtamentoPunti"] as int?,
                            Attenuante = (bool)reader["Attenuante"],
                            Aggravante = (bool)reader["Aggravante"]
                        };
                        verbali.Add(verbale);
                    }
                }
            }
            return verbali;
        }

        public void Add(Verbale verbale)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO VERBALI (IdAnagrafica, IdViolazione, DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Attenuante, Aggravante) VALUES (@IdAnagrafica, @IdViolazione, @DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @Attenuante, @Aggravante)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@Attenuante", verbale.Attenuante);
                cmd.Parameters.AddWithValue("@Aggravante", verbale.Aggravante);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Verbale verbale)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE VERBALI SET IdAnagrafica=@IdAnagrafica, IdViolazione=@IdViolazione, DataViolazione=@DataViolazione, IndirizzoViolazione=@IndirizzoViolazione, Nominativo_Agente=@Nominativo_Agente, DataTrascrizioneVerbale=@DataTrascrizioneVerbale, Importo=@Importo, DecurtamentoPunti=@DecurtamentoPunti, Attenuante=@Attenuante, Aggravante=@Aggravante WHERE IdVerbale=@IdVerbale";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVerbale", verbale.IdVerbale);
                cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@Attenuante", verbale.Attenuante);
                cmd.Parameters.AddWithValue("@Aggravante", verbale.Aggravante);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int idVerbale)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM VERBALI WHERE IdVerbale=@IdVerbale";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVerbale", idVerbale);
                cmd.ExecuteNonQuery();
            }
        }

        // Metodi per le statistiche
        public List<TotaleVerbaliPerTrasgressore> GetTotaleVerbaliPerTrasgressore()
        {
            List<TotaleVerbaliPerTrasgressore> risultati = new List<TotaleVerbaliPerTrasgressore>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT A.Cognome, A.Nome, COUNT(V.IdVerbale) AS NumeroVerbali
                    FROM VERBALI AS V
                    JOIN ANAGRAFICHE AS A ON V.IdAnagrafica = A.IdAnagrafica
                    GROUP BY A.Cognome, A.Nome";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TotaleVerbaliPerTrasgressore risultato = new TotaleVerbaliPerTrasgressore
                        {
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            NumeroVerbali = (int)reader["NumeroVerbali"]
                        };
                        risultati.Add(risultato);
                    }
                }
            }
            return risultati;
        }

        public List<TotalePuntiPerTrasgressore> GetTotalePuntiPerTrasgressore()
        {
            List<TotalePuntiPerTrasgressore> risultati = new List<TotalePuntiPerTrasgressore>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT A.Cognome, A.Nome, SUM(V.DecurtamentoPunti) AS TotalePuntiDecurtati
                    FROM VERBALI AS V
                    JOIN ANAGRAFICHE AS A ON V.IdAnagrafica = A.IdAnagrafica
                    GROUP BY A.Cognome, A.Nome";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TotalePuntiPerTrasgressore risultato = new TotalePuntiPerTrasgressore
                        {
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            TotalePuntiDecurtati = reader["TotalePuntiDecurtati"] as int?
                        };
                        risultati.Add(risultato);
                    }
                }
            }
            return risultati;
        }

        public List<ViolazioneSupera10Punti> GetViolazioniSupera10Punti()
        {
            List<ViolazioneSupera10Punti> risultati = new List<ViolazioneSupera10Punti>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT A.Cognome, A.Nome, V.DataViolazione, V.IndirizzoViolazione, V.Importo, V.DecurtamentoPunti
                    FROM VERBALI AS V
                    JOIN ANAGRAFICHE AS A ON V.IdAnagrafica = A.IdAnagrafica
                    WHERE V.DecurtamentoPunti > 10";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViolazioneSupera10Punti risultato = new ViolazioneSupera10Punti
                        {
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            DataViolazione = (DateTime)reader["DataViolazione"],
                            IndirizzoViolazione = (string)reader["IndirizzoViolazione"],
                            Importo = (decimal)reader["Importo"],
                            DecurtamentoPunti = (int)reader["DecurtamentoPunti"]
                        };
                        risultati.Add(risultato);
                    }
                }
            }
            return risultati;
        }

        public List<ViolazioneImportoMaggiore400> GetViolazioniImportoMaggiore400()
        {
            List<ViolazioneImportoMaggiore400> risultati = new List<ViolazioneImportoMaggiore400>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT A.Cognome, A.Nome, V.DataViolazione, V.IndirizzoViolazione, V.Importo, V.DecurtamentoPunti
                    FROM VERBALI AS V
                    JOIN ANAGRAFICHE AS A ON V.IdAnagrafica = A.IdAnagrafica
                    WHERE V.Importo > 400";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViolazioneImportoMaggiore400 risultato = new ViolazioneImportoMaggiore400
                        {
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            DataViolazione = (DateTime)reader["DataViolazione"],
                            IndirizzoViolazione = (string)reader["IndirizzoViolazione"],
                            Importo = (decimal)reader["Importo"],
                            DecurtamentoPunti = (int)reader["DecurtamentoPunti"]
                        };
                        risultati.Add(risultato);
                    }
                }
            }
            return risultati;
        }
    }
}
