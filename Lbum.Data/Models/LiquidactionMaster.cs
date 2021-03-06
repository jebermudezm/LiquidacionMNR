﻿using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class LiquidactionMaster
    {
        public int IdLiquidacion { get; set; }
        public int? IdFrontera { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaAplica { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public int IdVersion { get; set; }
        public string Factura { get; set; }

        public virtual EnergyMeter IdFronteraNavigation { get; set; }
        public virtual Version IdVersionNavigation { get; set; }
    }
}
