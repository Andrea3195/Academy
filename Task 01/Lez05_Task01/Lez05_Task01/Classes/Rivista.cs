using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_Task01.Classes
{
    internal class Rivista : Pubblicazione
    {
        public string? Titolo { get; set; }
        public string? Categoria { get; set; }

        public Rivista(string? titolo, string? categoria, float prezzo, string? periodicita, string? codice, int? stock)
        {
            Titolo = titolo;
            Categoria = categoria;
            Prezzo = prezzo;
            Periodicita = periodicita;
            Codice = codice;
            Stock = stock;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"[RIVISTA] Titolo: {Titolo}, Categoria: {Categoria}, Prezzo: {Prezzo}, Periodicità: {Periodicita}, Codice: {Codice}, Quantità: {Stock}\n");
        }
    }
}
