using System;
using System.Collections.Generic;

namespace WPF_neg_abb.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public DateOnly? DataOrdine { get; set; }

    public int QuantitaProdotti { get; set; }

    public int UtenteRif { get; set; }

    public int ProdottoRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
