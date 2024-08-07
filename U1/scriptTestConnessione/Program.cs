using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Stringa di connessione
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=PoliziaDb;Trusted_Connection=True;";

        // Creazione della connessione SQL
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Aprire la connessione
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                // Stampa dell'errore
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Aggiungere una pausa per visualizzare il risultato
        Console.WriteLine("Premi un tasto per uscire...");
        Console.ReadKey();
    }
}
