using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PoliziaApp.Models;

namespace PoliziaApp.DAO
{
    public class AnagraficaDAO : BaseDAO
    {
        public AnagraficaDAO(IConfiguration configuration) : base(configuration) { }

        public List<Anagrafica> GetAll()
        {
            List<Anagrafica> anagrafiche = new List<Anagrafica>();

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string sql = "SELECT * FROM ANAGRAFICHE";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Anagrafica anagrafica = new Anagrafica
                            {
                                IdAnagrafica = reader.GetInt32(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Indirizzo = reader.GetString(3),
                                Città = reader.GetString(4),
                                CAP = reader.GetString(5),
                                Cod_Fisc = reader.GetString(6)
                            };
                            anagrafiche.Add(anagrafica);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Logga l'eccezione SQL per ulteriori dettagli
                Console.WriteLine($"Errore SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Logga l'eccezione generale per ulteriori dettagli
                Console.WriteLine($"Errore Generale: {ex.Message}");
                throw;
            }

            return anagrafiche;
        }

        public void Add(Anagrafica anagrafica)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string sql = "INSERT INTO ANAGRAFICHE (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Città, @CAP, @Cod_Fisc)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Città", anagrafica.Città);
                    command.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fisc", anagrafica.Cod_Fisc);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                // Logga l'eccezione SQL per ulteriori dettagli
                Console.WriteLine($"Errore SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Logga l'eccezione generale per ulteriori dettagli
                Console.WriteLine($"Errore Generale: {ex.Message}");
                throw;
            }
        }

        public void Update(Anagrafica anagrafica)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string sql = "UPDATE ANAGRAFICHE SET Cognome = @Cognome, Nome = @Nome, Indirizzo = @Indirizzo, Città = @Città, CAP = @CAP, Cod_Fisc = @Cod_Fisc WHERE IdAnagrafica = @IdAnagrafica";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Città", anagrafica.Città);
                    command.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fisc", anagrafica.Cod_Fisc);
                    command.Parameters.AddWithValue("@IdAnagrafica", anagrafica.IdAnagrafica);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                // Logga l'eccezione SQL per ulteriori dettagli
                Console.WriteLine($"Errore SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Logga l'eccezione generale per ulteriori dettagli
                Console.WriteLine($"Errore Generale: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string sql = "DELETE FROM ANAGRAFICHE WHERE IdAnagrafica = @IdAnagrafica";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@IdAnagrafica", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                // Logga l'eccezione SQL per ulteriori dettagli
                Console.WriteLine($"Errore SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Logga l'eccezione generale per ulteriori dettagli
                Console.WriteLine($"Errore Generale: {ex.Message}");
                throw;
            }
        }
    }
}
