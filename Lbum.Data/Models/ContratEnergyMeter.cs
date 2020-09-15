using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class ContratEnergyMeter
    {
        public int IdContratoFrontera { get; set; }
        public int IdFrontera { get; set; }
        public int IdContrato { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Contrat IdContratoNavigation { get; set; }
        public virtual EnergyMeter IdFronteraNavigation { get; set; }
    }
}
