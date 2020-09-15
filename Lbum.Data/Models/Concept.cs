using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Concept
    {
        public Concept()
        {
            TblConceptoContrato = new HashSet<ConceptContrat>();
            TblConceptoFrontera = new HashSet<ConceptEnergyMeter>();
            TblConceptoMaestroObjeto = new HashSet<ConceptMasterObjet>();
            TblResultadoLiquidacion = new HashSet<LiquidationDetail>();
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

        public virtual ICollection<ConceptContrat> TblConceptoContrato { get; set; }
        public virtual ICollection<ConceptEnergyMeter> TblConceptoFrontera { get; set; }
        public virtual ICollection<ConceptMasterObjet> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<LiquidationDetail> TblResultadoLiquidacion { get; set; }
    }
}
