using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class City
    {
        public City()
        {
            TblEmpresa = new HashSet<Client>();
            TblEncabezadoFactura = new HashSet<InvoiceHeader>();
            TblFrontera = new HashSet<EnergyMeter>();
        }

        public int IdCiudad { get; set; }
        public int IdDepartamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoCentroPoblado { get; set; }
        public string NombreCentroPoblado { get; set; }
        public string Tipo { get; set; }

        public virtual Department IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Client> TblEmpresa { get; set; }
        public virtual ICollection<InvoiceHeader> TblEncabezadoFactura { get; set; }
        public virtual ICollection<EnergyMeter> TblFrontera { get; set; }
    }
}
