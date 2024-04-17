using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class PrezzoPieno
{
    public int PrezzoPienoId { get; set; }

    public double Valore { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
