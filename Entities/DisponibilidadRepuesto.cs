using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class DisponibilidadRepuesto
{
    public long Id { get; set; }

    public long IdSucursal { get; set; }

    public long UnidadesDisponibles { get; set; }

    public long RepuestoId { get; set; }

    public virtual Repuesto Repuesto { get; set; } = null!;
}
