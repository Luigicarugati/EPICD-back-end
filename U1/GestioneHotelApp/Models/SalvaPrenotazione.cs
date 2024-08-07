using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneHotelApp.Models
{
    public class SalvaPrenotazione
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string CodiceFiscaleCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string CognomeCliente { get; set; }

        [Required]
        public int NumeroCamera { get; set; }

        [StringLength(100)]
        public string DescrizioneCamera { get; set; }

        [StringLength(50)]
        public string TipologiaCamera { get; set; }

        [StringLength(100)]
        public string DescrizioneTrattamento { get; set; }

        [Required]
        public DateTime Dal { get; set; }

        [Required]
        public DateTime Al { get; set; }

        [Required]
        public DateTime DataPrenotazione { get; set; }

        [Required]
        public int NumeroProgressivoAnno { get; set; }

        [Required]
        public int Anno { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CaparraConfirmatoria { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TariffaApplicata { get; set; }

        [Required]
        public int TrattamentoId { get; set; }
    }
}
