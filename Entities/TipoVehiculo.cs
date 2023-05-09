using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class TipoVehiculo
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
