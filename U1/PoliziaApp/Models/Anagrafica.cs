namespace PoliziaApp.Models
{
    public class Anagrafica
    {
        public int IdAnagrafica { get; set; }
        public string Cognome { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Indirizzo { get; set; } = string.Empty;
        public string Città { get; set; } = string.Empty;
        public string CAP { get; set; } = string.Empty;
        public string Cod_Fisc { get; set; } = string.Empty;
    }
}
