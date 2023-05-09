using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Modelo
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public long MarcaId { get; set; }

    public virtual Marca Marca { get; set; } = null!;

    public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
