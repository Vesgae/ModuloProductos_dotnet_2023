﻿using System;
using System.Collections.Generic;

namespace Modulo_Productos.Entities;

public partial class FasexservicioAgendado
{
    public long Id { get; set; }

    public long FaseId { get; set; }

    public long ServicioAgendadoId { get; set; }

}
