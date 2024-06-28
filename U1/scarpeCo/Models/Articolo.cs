using System.ComponentModel.DataAnnotations;

namespace ScarpeCo.Models
{
    public class Articolo
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }

        public string Descrizione { get; set; }

        public string ImmagineCopertina { get; set; }

        public string ImmagineAggiuntiva1 { get; set; }

        public string ImmagineAggiuntiva2 { get; set; }
    }
}
