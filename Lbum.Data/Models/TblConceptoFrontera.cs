using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblConceptoFrontera
    {
        public int IdConceptoFrontera { get; set; }
        public int IdFrontera { get; set; }
        public int IdConcepto { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public string Estado { get; set; }
        public int IdVersion { get; set; }
        public double Valor { get; set; }

        public virtual TblConcepto IdConceptoNavigation { get; set; }
        public virtual TblFrontera IdFronteraNavigation { get; set; }
        public virtual TblVersion IdVersionNavigation { get; set; }
    }
}
