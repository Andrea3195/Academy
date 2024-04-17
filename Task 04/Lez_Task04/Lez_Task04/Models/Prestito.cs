using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez_Task04.Models
{
    internal class Prestito
    {
        public int Id { get; set; }
        public DateTime DataPrestito { get; set; }
        public DateTime DataRitorno { get; set; }
        public int UtenteRIF { get; set; }
        public int LibroRIF { get; set; }

        public Prestito() { }

        public Prestito(int id, DateTime dataPrestito, DateTime dataRitorno, int utenteRIF, int libroRIF)
        {
            Id = id;
            DataPrestito = dataPrestito;
            DataRitorno = dataRitorno;
            UtenteRIF = utenteRIF;
            LibroRIF = libroRIF;
        }
    }
}
