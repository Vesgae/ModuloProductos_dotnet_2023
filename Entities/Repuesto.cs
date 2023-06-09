﻿using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Repuesto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public double Precio { get; set; }

    public long ModeloId { get; set; }

    public long ProductoId { get; set; }

}
