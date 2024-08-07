using System;
using System.Collections.Generic;

namespace GestioneHotelApp.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public string CodiceFiscaleCliente { get; set; }
        public int NumeroCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int NumeroProgressivoAnno { get; set; }
        public int Anno { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public decimal CaparraConfirmatoria { get; set; }
        public decimal TariffaApplicata { get; set; }
        public int TrattamentoId { get; set; }

        public Cliente Cliente { get; set; }
        public Camera Camera { get; set; }
        public Trattamento Trattamento { get; set; }
        public List<PrenotazioneServizio> PrenotazioniServizi { get; set; }
    }
}