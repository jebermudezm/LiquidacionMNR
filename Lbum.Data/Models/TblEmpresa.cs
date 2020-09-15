using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblEmpresa
    {
        public TblEmpresa()
        {
            TblEncabezadoFactura = new HashSet<TblEncabezadoFactura>();
        }

        public int IdEmpresa { get; set; }
        public string IdInterno { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdCiudad { get; set; }
        public int? IdCiiu { get; set; }

        public virtual TblCiudad IdCiudadNavigation { get; set; }
        public virtual ICollection<TblEncabezadoFactura> TblEncabezadoFactura { get; set; }
    }
}
