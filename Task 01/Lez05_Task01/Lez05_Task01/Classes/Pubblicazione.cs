using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_Task01.Classes
{
    public abstract class Pubblicazione
    {
        public float Prezzo { get; set; }
        public string? Periodicita { get; set; }
        public string? Codice { get; set; }
        public int? Stock { get; set; }

        public abstract void stampaDettaglio();
    }
}
