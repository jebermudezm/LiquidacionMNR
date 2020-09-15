using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Client
    {
        public Client()
        {
            TblEncabezadoFactura = new HashSet<InvoiceHeader>();
        }

        public int IdEmpresa { get; set; }
        public string IdInterno { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdCiudad { get; set; }
        public int? IdCiiu { get; set; }

        public virtual City IdCiudadNavigation { get; set; }
        public virtual ICollection<InvoiceHeader> TblEncabezadoFactura { get; set; }
    }
}
