using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez_Task04.Models
{
    internal class Libro : Prestito
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public DateTime AnnoPubblicazione { get; set; }
        public bool IsDisponibile { get; set; }

        public Libro() { }
        public Libro(int id, string? titolo, DateTime annoPubblicazione, bool isDisponibile)
        {
            Id = id;
            Titolo = titolo;
            AnnoPubblicazione = annoPubblicazione;
            IsDisponibile = isDisponibile;
        }
    }
}
