namespace PoliziaApp.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        public int IdAnagrafica { get; set; }
        public int IdViolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; } = string.Empty;
        public string Nominativo_Agente { get; set; } = string.Empty;
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int? DecurtamentoPunti { get; set; }
        public bool Attenuante { get; set; }
        public bool Aggravante { get; set; }
    }
}
