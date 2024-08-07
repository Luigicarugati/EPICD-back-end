using System.ComponentModel.DataAnnotations;

namespace GestioneHotelApp.Models
{
    public class Cliente
    {
        [Required]
        [StringLength(16)]
        public string CodiceFiscale { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Citta { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Phone]
        [StringLength(15)]
        public string Cellulare { get; set; }
    }
}
