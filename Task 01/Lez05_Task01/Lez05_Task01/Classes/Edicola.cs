using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_Task01.Classes
{
    internal class Edicola
    {
        public string? Nome { get; set; }

        public string? Indirizzo { get; set; }

        public List<Pubblicazione> magazzino { get; set; } = new List<Pubblicazione>();

        public Edicola(string? nome, string? indirizzo)
        {
            Nome = nome;
            Indirizzo = indirizzo;
        }

        public void aggiungiPub(Pubblicazione pub)
        {
            bool codiceEsistente = false;

            foreach (Pubblicazione p in magazzino)
            {
                if (p.Codice == pub.Codice)
                {
                    codiceEsistente = true;
                    break;
                }
            }
            if (!codiceEsistente)
            {
                magazzino.Add(pub);
                Console.WriteLine("Pubblicazione aggiunta!\n");
            }
            else
            {
                Console.WriteLine("ERRORE: Pubblicazione già esistente!\n");
            }

        }

        public void rimuoviPub(string? codice)
        {
            foreach (Pubblicazione p in magazzino)
            {
                if (p.Codice == codice)
                {
                    magazzino.Remove(p);
                    Console.WriteLine("Pubblicazione rimossa!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("ERRORE: Pubblicazione non trovata!\n");
                }
            }
        }
        
        public void aggiornaDisp(string? codice, int? stock)
        {
            foreach (Pubblicazione p in magazzino)
            {
                if (p.Codice == codice)
                {
                    p.Stock += stock;
                    Console.WriteLine("Stock aggiornato!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Stock non aggiornato!\n");
                }
            }
        }

        public void visualizzaPub()
        {
            foreach (Pubblicazione pub in magazzino)
            {
                pub.stampaDettaglio();
            }
        }
    }
}
