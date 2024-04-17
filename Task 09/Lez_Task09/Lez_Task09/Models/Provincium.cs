using System;
using System.Collections.Generic;

namespace Lez_Task09.Models;

public partial class Provincium
{
    public int ProvinciaId { get; set; }

    public string Sigla { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public virtual ICollection<Cittum> Citta { get; set; } = new List<Cittum>();
}
