using esercitazione3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercitazione3
{
 
    public class ContoCorrente
    {
        private string _cognomeCorrentista = string.Empty;
        public string CognomeCorrentista
        {
            get { return _cognomeCorrentista; }
            set { _cognomeCorrentista = value; }
        }

        private string _nomeCorrentista = string.Empty;
        public string NomeCorrentista
        {
            get { return _nomeCorrentista; }
            set { _nomeCorrentista = value; }
        }

        private decimal _saldo = 0;
        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        private bool _contoAperto = false;
        public bool ContoAperto
        {
            get { return _contoAperto; }
            set { _contoAperto = value; }
        }

        public ContoCorrente() { }

        public void MenuInizialeStart()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("I N T E S A   S A N   GIOVANNI   B A N K");
                Console.WriteLine("==========================================");

                Console.WriteLine("\nScegli l'operazione da effettuare:");
                Console.WriteLine("1. APRI NUOVO CONTO CORRENTE");
                Console.WriteLine("2. EFFETTUA UN VERSAMENTO");
                Console.WriteLine("3. EFFETTUA UN PRELEVAMENTO");
                Console.WriteLine("4. ESCI");

                if (int.TryParse(Console.ReadLine(), out int scelta))
                {
                    switch (scelta)
                    {
                        case 1:
                            ApriNuovoContoCorrente();
                            break;
                        case 2:
                            EffettuaVersamento();
                            break;
                        case 3:
                            EffettuaPrelevamento();
                            break;
                        case 4:
                            Console.WriteLine("Chiusura programma in corso");
                            return;
                        default:
                            Console.WriteLine("Hai selezionato una voce non valida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }
            }
        }

        private void ApriNuovoContoCorrente()
        {
            Console.WriteLine("Cognome Correntista: ");
            string? cognome = Console.ReadLine();
            if (string.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Il cognome non può essere vuoto.");
                return;
            }
            _cognomeCorrentista = cognome;

            Console.WriteLine("Nome Correntista: ");
            string? nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Il nome non può essere vuoto.");
                return;
            }
            _nomeCorrentista = nome;

            _saldo = 0;
            _contoAperto = true;
            Console.WriteLine($"Conto corrente nr. 2555411 intestato a: {_cognomeCorrentista} {_nomeCorrentista} aperto correttamente");
        }

        private void EffettuaPrelevamento()
        {
            if (!_contoAperto)
            {
                Console.WriteLine("È necessario aprire un conto prima di effettuare un prelevamento");
                return;
            }

            Console.WriteLine("Inserisci l'importo del prelevamento da effettuare: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal importoPrelevato))
            {
                if (importoPrelevato > _saldo)
                {
                    Console.WriteLine("Prelevamento non consentito!!!");
                }
                else
                {
                    Console.WriteLine("Prelevamento effettuato");
                    _saldo -= importoPrelevato;
                    Console.WriteLine($"Nuovo saldo del CC odierno: {_saldo.ToString("N")}");
                }
            }
            else
            {
                Console.WriteLine("Importo non valido.");
            }
        }

        private void EffettuaVersamento()
        {
            if (!_contoAperto)
            {
                Console.WriteLine("È necessario aprire un conto prima di effettuare un versamento");
                return;
            }

            Console.WriteLine("Inserisci l'importo del versamento da effettuare: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal importoVersato))
            {
                Console.WriteLine("Versamento effettuato");
                _saldo += importoVersato;
                Console.WriteLine($"Nuovo saldo del CC odierno: {_saldo.ToString("N")}");
            }
            else
            {
                Console.WriteLine("Importo non valido.");
            }
        }

        
    }

}
