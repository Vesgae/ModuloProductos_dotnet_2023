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

}
