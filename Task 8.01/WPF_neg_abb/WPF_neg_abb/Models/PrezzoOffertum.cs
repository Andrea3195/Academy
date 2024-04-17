using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class PrezzoOffertum
{
    public int PrezzoOffertaId { get; set; }

    public double Valore { get; set; }

    public DateOnly DataInizio { get; set; }

    public DateOnly DataFine { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
