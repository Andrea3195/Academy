using System;
using System.Collections.Generic;

namespace Lez_Task09.Models;

public partial class Cittum
{
    public int CittaId { get; set; }

    public string Nome { get; set; } = null!;

    public int ProvinciaRif { get; set; }

    public virtual Provincium ProvinciaRifNavigation { get; set; } = null!;
}
