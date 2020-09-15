using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblConcepto
    {
        public TblConcepto()
        {
            TblConceptoContrato = new HashSet<TblConceptoContrato>();
            TblConceptoFrontera = new HashSet<TblConceptoFrontera>();
            TblConceptoMaestroObjeto = new HashSet<TblConceptoMaestroObjeto>();
            TblResultadoLiquidacion = new HashSet<TblResultadoLiquidacion>();
        }

        public int IdConcepto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public double? PorcentajeIva { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdTipoConcepto { get; set; }
        public string NumeroMaterial { get; set; }

        public virtual ICollection<TblConceptoContrato> TblConceptoContrato { get; set; }
        public virtual ICollection<TblConceptoFrontera> TblConceptoFrontera { get; set; }
        public virtual ICollection<TblConceptoMaestroObjeto> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<TblResultadoLiquidacion> TblResultadoLiquidacion { get; set; }
    }
}
