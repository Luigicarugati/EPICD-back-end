namespace PoliziaMunicipaleApp.Models
{
    public class Anagrafiche
    {
        public int Idanagrafica { get; set; }
        public string Cognome { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Indirizzo { get; set; } = string.Empty;
        public string Città { get; set; } = string.Empty;
        public string CAP { get; set; } = string.Empty;
        public string Cod_Fisc { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Verbali> Verbali { get; set; } = [];
    }

    public class TipiViolazione
    {
        public int Idviolazione { get; set; }
        public string Descrizione { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Verbali> Verbali { get; set; } = [];
    }

    public class Verbali
    {
        public int Idverbale { get; set; }
        public int Idanagrafica { get; set; }
        public int Idviolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; } = string.Empty;
        public string Nominativo_Agente { get; set; } = string.Empty;
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }

        // Navigation properties
        public Anagrafiche Anagrafiche { get; set; } = null!;
        public TipiViolazione TipiViolazione { get; set; } = null!;
    }
}
