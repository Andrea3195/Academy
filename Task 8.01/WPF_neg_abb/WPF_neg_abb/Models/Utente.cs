using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string? Mail { get; set; }

    public string CodiceUtente { get; set; } = null!;

    public DateTime? Deleted { get; set; }

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();
}
