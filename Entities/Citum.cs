using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Citum
{
    public long Id { get; set; }

    public DateTime Fecha { get; set; }

    public long ServicioAgendadoId { get; set; }

}
