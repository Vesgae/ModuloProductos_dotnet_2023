using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class FotoServicio
{
    public long Id { get; set; }

    public string Url { get; set; } = null!;

    public long ServicioId { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;
}
