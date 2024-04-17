using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class Gallerium
{
    public int GalleriaId { get; set; }

    public int ProdottoRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
