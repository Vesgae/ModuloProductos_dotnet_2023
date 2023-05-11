using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Alertasxvehiculo
{
    public long Id { get; set; }

    public long AlertaId { get; set; }

    public long VehiculoId { get; set; }

}
