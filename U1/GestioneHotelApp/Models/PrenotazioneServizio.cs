using System;

namespace GestioneHotelApp.Models
{
    public class PrenotazioneServizio
    {
        public int Id { get; set; }
        public int IdPrenotazione { get; set; }
        public int ServizioId { get; set; }
        public DateTime Data { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }

        // Navigational properties
        public Prenotazione Prenotazione { get; set; }
        public Servizio Servizio { get; set; }
    }
}
