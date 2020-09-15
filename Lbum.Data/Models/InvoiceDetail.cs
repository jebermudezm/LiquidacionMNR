using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class InvoiceDetail
    {
        public int IdDetalle { get; set; }
        public int IdEncabezado { get; set; }
        public int? IdConcepto { get; set; }
        public string Descripcion { get; set; }
        public double? Cantidad { get; set; }
        public int? Hora { get; set; }
        public string TipoDetalle { get; set; }
        public double? Valor { get; set; }
        public double? ValorIva { get; set; }

        public virtual InvoiceHeader IdEncabezadoNavigation { get; set; }
    }
}
