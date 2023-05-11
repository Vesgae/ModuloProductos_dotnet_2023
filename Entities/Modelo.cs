using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Modelo
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public long MarcaId { get; set; }

}
