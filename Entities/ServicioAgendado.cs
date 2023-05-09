﻿using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class ServicioAgendado
{
    public long Id { get; set; }

    public DateTime FechaDeIngreso { get; set; }

    public DateTime? FechaDeSalida { get; set; }

    public DateTime FechaDeUltimaActualizacion { get; set; }

    public long IdEmpleado { get; set; }

    public long IdFaseSeleccionada { get; set; }

    public string Reportes { get; set; } = null!;

    public long ServicioId { get; set; }

    public long VehiculoId { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<FasexservicioAgendado> FasexservicioAgendados { get; set; } = new List<FasexservicioAgendado>();

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}
