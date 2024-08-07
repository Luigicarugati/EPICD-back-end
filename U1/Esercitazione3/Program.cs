namespace esercitazione3
{
    internal class Program
    {
        static void Main(string[] args)
        {
                ContoCorrente cc = new ContoCorrente();
                cc.MenuInizialeStart();

            string[] listanomi = { "francesco", "marco", "mario", "chiara", "lorenzo" };
            string nome;
            int i;
            bool verifica = false;

            Console.WriteLine("Inserire il nome da ricercare");
            nome = Console.ReadLine();

            for (i = 0; i < listanomi.Length; i++)
            {
                if (listanomi[i] == nome)
                {
                    Console.WriteLine("Il nome è presente nella lista");
                    verifica = true;
                }

            }
            if (verifica == false)
            {
                Console.WriteLine("Il nome non è presente nella lista");
            }

            Console.ReadLine();

            {
                int x = 0;
                Console.WriteLine("Specifica dimensione array");
                x = int.Parse(Console.ReadLine());
                int[] listanumeri = new int[x];
                int somma = 0;


                int i;
                for (i = 0; i < listanumeri.Length; i++)
                {
                    Console.WriteLine("Inserisci numero");
                    listanumeri[i] = int.Parse(Console.ReadLine());
                }
                for (i = 0; i < listanumeri.Length; i++)
                {
                    somma += listanumeri[i];
                }
                Console.WriteLine($"\nLa somma è: {somma}\n");
                Console.WriteLine($"La media è: {somma / x}");
                Console.ReadLine();
            }
        }

    }

}
    



