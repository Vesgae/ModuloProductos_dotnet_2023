using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Marca
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
