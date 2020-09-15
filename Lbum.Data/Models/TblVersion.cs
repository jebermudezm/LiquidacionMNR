using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblVersion
    {
        public TblVersion()
        {
            TblConceptoFrontera = new HashSet<TblConceptoFrontera>();
            TblConceptoMaestroObjeto = new HashSet<TblConceptoMaestroObjeto>();
            TblLiquidacion = new HashSet<TblLiquidacion>();
            TblResultadoLiquidacion = new HashSet<TblResultadoLiquidacion>();
        }

        public int IdVersion { get; set; }
        public string VersionDatos { get; set; }
        public int VesionNumerica { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<TblConceptoFrontera> TblConceptoFrontera { get; set; }
        public virtual ICollection<TblConceptoMaestroObjeto> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<TblLiquidacion> TblLiquidacion { get; set; }
        public virtual ICollection<TblResultadoLiquidacion> TblResultadoLiquidacion { get; set; }
    }
}
