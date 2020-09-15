using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblListasDetalle
    {
        public int IdListaDetalle { get; set; }
        public int IdLista { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
