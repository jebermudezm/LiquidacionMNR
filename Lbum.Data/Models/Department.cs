using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            TblCiudad = new HashSet<City>();
            TblEncabezadoFactura = new HashSet<InvoiceHeader>();
        }

        public int IdDepartamento { get; set; }
        public int IdPais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual Country IdPaisNavigation { get; set; }
        public virtual ICollection<City> TblCiudad { get; set; }
        public virtual ICollection<InvoiceHeader> TblEncabezadoFactura { get; set; }
    }
}
