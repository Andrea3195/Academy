using System;
using System.Collections.Generic;

namespace Lez_Task09.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public int? Matricola { get; set; }

    public string? Nome { get; set; }

    public string? Cognome { get; set; }

    public DateOnly? DataNascita { get; set; }

    public string? Ruolo { get; set; }

    public string? Indirizzo { get; set; }
}
