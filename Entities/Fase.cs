using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Fase
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<FasexservicioAgendado> FasexservicioAgendados { get; set; } = new List<FasexservicioAgendado>();
}
