namespace GestioneHotelApp.Models
{
#nullable enable

    // Modello per visualizzare gli errori
    public class ErrorViewModel
    {
        // Identificatore univoco della richiesta, può essere null
        public string? RequestId { get; set; }

        // Proprietà per determinare se mostrare l'identificatore della richiesta
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
