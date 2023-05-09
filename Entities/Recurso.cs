using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Recurso
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<DisponibilidadRecurso> DisponibilidadRecursos { get; set; } = new List<DisponibilidadRecurso>();

    public virtual ICollection<Servicioxrecurso> Servicioxrecursos { get; set; } = new List<Servicioxrecurso>();
}
