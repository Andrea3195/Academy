using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_Task01.Classes
{
    internal class Giornale : Pubblicazione
    {
        public string? Redazione { get; set; }
        public int NumPagine { get; set; }

        public Giornale(string? redazione, int numPagine, float prezzo, string? periodicita, string? codice, int? stock)
        {
            Redazione = redazione;
            NumPagine = numPagine;
            Prezzo = prezzo;
            Periodicita = periodicita;
            Codice = codice;
            Stock = stock;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"[GIORNALE] Redazione: {Redazione}, Numero Pagine: {NumPagine}, Prezzo: {Prezzo}, Periodicità: {Periodicita}, Codice: {Codice}, Quantità: {Stock}\n");
        }
    }
}
