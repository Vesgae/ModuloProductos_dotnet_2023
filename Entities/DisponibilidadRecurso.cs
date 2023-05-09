using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class DisponibilidadRecurso
{
    public long Id { get; set; }

    public long IdSucursal { get; set; }

    public long UnidadesDisponibles { get; set; }

    public long RecursoId { get; set; }

    public virtual Recurso Recurso { get; set; } = null!;
}
