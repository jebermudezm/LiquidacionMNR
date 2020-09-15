using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class ConsecutiveDocument
    {
        public ConsecutiveDocument()
        {
            TblEncabezadoFactura = new HashSet<InvoiceHeader>();
        }

        public int IdConsecutivoDocumento { get; set; }
        public string Prefijo { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<InvoiceHeader> TblEncabezadoFactura { get; set; }
    }
}
