using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class ConceptEnergyMeter
    {
        public int IdConceptoFrontera { get; set; }
        public int IdFrontera { get; set; }
        public int IdConcepto { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public string Estado { get; set; }
        public int IdVersion { get; set; }
        public double Valor { get; set; }

        public virtual Concept IdConceptoNavigation { get; set; }
        public virtual EnergyMeter IdFronteraNavigation { get; set; }
        public virtual Version IdVersionNavigation { get; set; }
    }
}
