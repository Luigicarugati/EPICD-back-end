using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcoloimposta
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public double CalcolaImposta()
        {
            double imposta = 0.0;
            double imponibile = RedditoAnnuale; 

            if (RedditoAnnuale <= 15000)
            {
                imposta = imponibile * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (imponibile - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (imponibile - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (imponibile - 55000) * 0.41;
            }
            else
            {
                imposta = 25420 + (imponibile - 75000) * 0.43;
            }

            return imposta;
        }

        public override string ToString()
        {
            return $"Contribuente: {Nome} {Cognome},\nnato il {DataNascita:dd/MM/yyyy} ({Sesso}),\nresidente in {ComuneResidenza},\ncodice fiscale: {CodiceFiscale}\nReddito dichiarato: {RedditoAnnuale:C2}\nIMPOSTA DA VERSARE: {CalcolaImposta():C2}";
        }
    }


}
