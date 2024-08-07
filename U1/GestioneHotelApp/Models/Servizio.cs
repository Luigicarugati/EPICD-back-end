using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneHotelApp.Models
{
    public class Servizio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Prezzo { get; set; }

        // Proprietà di navigazione per le relazioni con PrenotazioneServizio
        public ICollection<PrenotazioneServizio> PrenotazioniServizi { get; set; }
    }
}
