using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneHotelApp.Models
{
    public class Trattamento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TariffaSupplementare { get; set; }
    }
}
