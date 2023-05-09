using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Servicio
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public double Precio { get; set; }

    public long TipoServicioId { get; set; }

    public virtual ICollection<FotoServicio> FotoServicios { get; set; } = new List<FotoServicio>();

    public virtual ICollection<ServicioAgendado> ServicioAgendados { get; set; } = new List<ServicioAgendado>();

    public virtual ICollection<Servicioxrecurso> Servicioxrecursos { get; set; } = new List<Servicioxrecurso>();

    public virtual TipoServicio TipoServicio { get; set; } = null!;
}
