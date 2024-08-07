using System;
using System.Globalization;


namespace Calcoloimposta
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CultureInfo.CurrentCulture = new CultureInfo("it-IT");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool continua = true;

            while (continua)
            {
                Console.WriteLine("Inserisci i dati del contribuente:");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();

                Console.Write("Data di nascita (gg/mm/aaaa): ");
                DateTime dataNascita = DateTime.Parse(Console.ReadLine());

                Console.Write("Codice Fiscale: ");
                string codiceFiscale = Console.ReadLine();

                Console.Write("Sesso (M/F): ");
                char sesso = char.Parse(Console.ReadLine());

                Console.Write("Comune di Residenza: ");
                string comuneResidenza = Console.ReadLine();

                Console.Write("Reddito Annuale: ");
                double redditoAnnuale = double.Parse(Console.ReadLine());

                Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

                Console.WriteLine("==================================================");
                Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
                Console.WriteLine(contribuente);

                Console.WriteLine("Vuoi calcolare l'imposta per un altro contribuente? (s/n): ");
                string risposta = Console.ReadLine().ToLower();

                if (risposta != "s")
                {
                    continua = false;
                }
            }
        }
    }
}
