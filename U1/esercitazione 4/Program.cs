using System;

namespace esercitazione_4

{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============MENU==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Registrati");
                Console.WriteLine("2.: Login");
                Console.WriteLine("3.: Logout");
                Console.WriteLine("4.: Verifica ora e data di login");
                Console.WriteLine("5.: Lista degli accessi");
                Console.WriteLine("6.: Esci");
                Console.WriteLine("========================================");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformRegistration();
                        break;
                    case "2":
                        PerformLogin();
                        break;
                    case "3":
                        PerformLogout();
                        break;
                    case "4":
                        CheckLoginTime();
                        break;
                    case "5":
                        ShowAccessList();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Scelta non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PerformRegistration()
        {
            Console.Write("Inserisci username: ");
            string username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();

            Console.Write("Conferma password: ");
            string confirmPassword = Console.ReadLine();

            if (Utente.Register(username, password, confirmPassword))
            {
                Console.WriteLine("Registrazione effettuata con successo!");
            }
            else
            {
                Console.WriteLine("Errore nella registrazione. Assicurati che la username sia inserita, le password coincidano e lo username non sia già esistente.");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        static void PerformLogin()
        {
            Console.Write("Inserisci username: ");
            string username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();

            if (Utente.Login(username, password))
            {
                Console.WriteLine("Login effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel login. Assicurati che le credenziali siano corrette.");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        static void PerformLogout()
        {
            if (Utente.Username != null)
            {
                Utente.Logout();
                Console.WriteLine("Logout effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Nessun utente risulta loggato.");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        static void CheckLoginTime()
        {
            DateTime? loginTime = Utente.GetLoginTime();
            if (loginTime != null)
            {
                Console.WriteLine($"Data e ora di login: {loginTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente risulta loggato.");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        static void ShowAccessList()
        {
            if (Utente.IsAdmin())
            {
                var accessList = Utente.GetAccessList();
                if (accessList.Count > 0)
                {
                    Console.WriteLine("Lista degli accessi:");
                    foreach (var access in accessList)
                    {
                        Console.WriteLine(access);
                    }
                }
                else
                {
                    Console.WriteLine("Nessun accesso registrato.");
                }
            }
            else
            {
                Console.WriteLine("Accesso negato. Solo l'utente admin può visualizzare la lista degli accessi.");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}
