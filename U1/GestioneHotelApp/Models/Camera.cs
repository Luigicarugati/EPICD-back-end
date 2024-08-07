using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneHotelApp.Models
{
    public class Camera
    {
        [Required]
        public int Numero { get; set; }

        [StringLength(100)]
        public string Descrizione { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipologia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TariffaBase { get; set; }
    }
}
