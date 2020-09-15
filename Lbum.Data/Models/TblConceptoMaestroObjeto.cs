using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblConceptoMaestroObjeto
    {
        public int IdConceptoMaestroObjeto { get; set; }
        public int IdMaestroObjeto { get; set; }
        public int IdConcepto { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public int IdVersion { get; set; }
        public string Estado { get; set; }
        public double Valor { get; set; }

        public virtual TblConcepto IdConceptoNavigation { get; set; }
        public virtual TblMaestroObjeto IdMaestroObjetoNavigation { get; set; }
        public virtual TblVersion IdVersionNavigation { get; set; }
    }
}
