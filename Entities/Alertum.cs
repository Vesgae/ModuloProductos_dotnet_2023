using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Alertum
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public string Fecha { get; set; } = null!;

    public string Nombre { get; set; } = null!;

}
