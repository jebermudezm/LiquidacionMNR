using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblConsecutivoDocumento
    {
        public TblConsecutivoDocumento()
        {
            TblEncabezadoFactura = new HashSet<TblEncabezadoFactura>();
        }

        public int IdConsecutivoDocumento { get; set; }
        public string Prefijo { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<TblEncabezadoFactura> TblEncabezadoFactura { get; set; }
    }
}
