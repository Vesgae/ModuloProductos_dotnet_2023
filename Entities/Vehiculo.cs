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

    public virtual ICollection<Alertasxvehiculo> Alertasxvehiculos { get; set; } = new List<Alertasxvehiculo>();

    public virtual Modelo Modelo { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual ICollection<ServicioAgendado> ServicioAgendados { get; set; } = new List<ServicioAgendado>();

    public virtual TipoCombustible TipoCombustible { get; set; } = null!;

    public virtual TipoVehiculo TipoVehiculo { get; set; } = null!;
}
