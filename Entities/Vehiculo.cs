using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class Vehiculo
{
    public long Id { get; set; }

    public string Chasis { get; set; } = null!;

    public string Color { get; set; } = null!;

    public long? IdDuenio { get; set; }

    public string Placa { get; set; } = null!;

    public double Precio { get; set; }

    public long ModeloId { get; set; }

    public long? ProductoId { get; set; }

    public long TipoCombustibleId { get; set; }

    public long TipoVehiculoId { get; set; }
}
