using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Binnacle
    {
        public int IdBitacora { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Version { get; set; }
    }
}
