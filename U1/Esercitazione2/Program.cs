namespace Esercitazione2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona ("Mario","Rossi",30);

            Console.WriteLine("Nome: " + persona.GetNome());
            Console.WriteLine("Cognome: " + persona.GetCognome());
            Console.WriteLine("Età: " + persona.GetEta());
            Console.WriteLine("Dettagli: " + persona.GetDettagli());
        }
    }
}
