using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblCiudad
    {
        public TblCiudad()
        {
            TblEmpresa = new HashSet<TblEmpresa>();
            TblEncabezadoFactura = new HashSet<TblEncabezadoFactura>();
            TblFrontera = new HashSet<TblFrontera>();
        }

        public int IdCiudad { get; set; }
        public int IdDepartamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoCentroPoblado { get; set; }
        public string NombreCentroPoblado { get; set; }
        public string Tipo { get; set; }

        public virtual TblDepartamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<TblEmpresa> TblEmpresa { get; set; }
        public virtual ICollection<TblEncabezadoFactura> TblEncabezadoFactura { get; set; }
        public virtual ICollection<TblFrontera> TblFrontera { get; set; }
    }
}
