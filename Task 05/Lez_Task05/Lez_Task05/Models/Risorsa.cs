using System;
using System.Collections.Generic;

namespace Lez_Task05.Models;

public partial class Risorsa
{
    public int RisorsaId { get; set; }

    public string Atrezzatura { get; set; } = null!;

    public string Cibo { get; set; } = null!;

    public int Quantita { get; set; }

    public decimal Costo { get; set; }

    public string Fornitore { get; set; } = null!;

    public int EventoRif { get; set; }

    public virtual Evento EventoRifNavigation { get; set; } = null!;
}
