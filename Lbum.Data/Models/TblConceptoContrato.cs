﻿using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblConceptoContrato
    {
        public int IdConceptoContrato { get; set; }
        public int IdConcepto { get; set; }
        public int IdContrato { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime? FechaBase { get; set; }
        public double Valor { get; set; }

        public virtual TblConcepto IdConceptoNavigation { get; set; }
        public virtual TblContrato IdContratoNavigation { get; set; }
    }
}
