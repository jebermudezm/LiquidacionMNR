using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblDepartamento
    {
        public TblDepartamento()
        {
            TblCiudad = new HashSet<TblCiudad>();
            TblEncabezadoFactura = new HashSet<TblEncabezadoFactura>();
        }

        public int IdDepartamento { get; set; }
        public int IdPais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual TblPais IdPaisNavigation { get; set; }
        public virtual ICollection<TblCiudad> TblCiudad { get; set; }
        public virtual ICollection<TblEncabezadoFactura> TblEncabezadoFactura { get; set; }
    }
}
