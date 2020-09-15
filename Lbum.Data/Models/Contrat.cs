using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Contrat
    {
        public Contrat()
        {
            TblConceptoContrato = new HashSet<ConceptContrat>();
            TblContratoFrontera = new HashSet<ContratEnergyMeter>();
            TblResultadoLiquidacion = new HashSet<LiquidationDetail>();
        }

        public int IdContrato { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string TipoFactura { get; set; }
        public int? IdEmpresaCompra { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? DiasVencimiento { get; set; }
        public string TipoPrecioBolsa { get; set; }

        public virtual ICollection<ConceptContrat> TblConceptoContrato { get; set; }
        public virtual ICollection<ContratEnergyMeter> TblContratoFrontera { get; set; }
        public virtual ICollection<LiquidationDetail> TblResultadoLiquidacion { get; set; }
    }
}
