using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class FotoProducto
{
    public long Id { get; set; }

    public string Url { get; set; } = null!;

    public long ProductoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
