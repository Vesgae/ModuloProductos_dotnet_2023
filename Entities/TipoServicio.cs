using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class TipoServicio
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
