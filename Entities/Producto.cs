using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Producto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<FotoProducto> FotoProductos { get; set; } = new List<FotoProducto>();

    public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
