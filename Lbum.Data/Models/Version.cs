using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Version
    {
        public Version()
        {
            TblConceptoFrontera = new HashSet<ConceptEnergyMeter>();
            TblConceptoMaestroObjeto = new HashSet<ConceptMasterObjet>();
            TblLiquidacion = new HashSet<LiquidactionMaster>();
            TblResultadoLiquidacion = new HashSet<LiquidationDetail>();
        }

        public int IdVersion { get; set; }
        public string VersionDatos { get; set; }
        public int VesionNumerica { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<ConceptEnergyMeter> TblConceptoFrontera { get; set; }
        public virtual ICollection<ConceptMasterObjet> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<LiquidactionMaster> TblLiquidacion { get; set; }
        public virtual ICollection<LiquidationDetail> TblResultadoLiquidacion { get; set; }
    }
}
