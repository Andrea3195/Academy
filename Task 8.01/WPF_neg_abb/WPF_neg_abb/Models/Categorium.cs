using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
