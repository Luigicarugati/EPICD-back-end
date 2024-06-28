using System;

namespace scarpeCo.Models

{
    public class CartItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
    }
}
