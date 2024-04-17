using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public bool? IsDisponibile { get; set; }

    public int QuantitaProdotto { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int CategoriaRif { get; set; }

    public int PrezzoPienoRif { get; set; }

    public int PrezzoOffertaRif { get; set; }

    public DateTime? Deleted { get; set; }

    public string CodiceProdotto { get; set; } = null!;

    public virtual Categorium CategoriaRifNavigation { get; set; } = null!;

    public virtual ICollection<Gallerium> Galleria { get; set; } = new List<Gallerium>();

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();

    public virtual PrezzoOffertum PrezzoOffertaRifNavigation { get; set; } = null!;

    public virtual PrezzoPieno PrezzoPienoRifNavigation { get; set; } = null!;
}
