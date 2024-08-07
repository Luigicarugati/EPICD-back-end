
// JavaScript base per l'applicazione
console.log("site.js caricato correttamente.");

// Inizializzazione di eventuali plugin o funzionalità all'avvio del documento
$(document).ready(function () {
    // Codice per gestire eventuali comportamenti specifici
    console.log("Documento pronto");


    // Esempio: Gestione click su un pulsante
    $("#myButton").click(function () {
        alert("Bottone cliccato!");
    });
});
