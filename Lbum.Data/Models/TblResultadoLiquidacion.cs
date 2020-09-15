﻿using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblResultadoLiquidacion
    {
        public int IdResultadoLiquidacion { get; set; }
        public int IdConcepto { get; set; }
        public int IdMaestro { get; set; }
        public int? IdContrato { get; set; }
        public int? IdFrontera { get; set; }
        public DateTime FechaAplica { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public int IdVersion { get; set; }
        public double Valor { get; set; }
        public string Texto { get; set; }
        public string Factura { get; set; }
        public int? IdLiquidacion { get; set; }

        public virtual TblConcepto IdConceptoNavigation { get; set; }
        public virtual TblContrato IdContratoNavigation { get; set; }
        public virtual TblFrontera IdFronteraNavigation { get; set; }
        public virtual TblMaestroObjeto IdMaestroNavigation { get; set; }
        public virtual TblVersion IdVersionNavigation { get; set; }
    }
}
