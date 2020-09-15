using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblReporte
    {
        public int IdReporte { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Titulos { get; set; }
        public string Consulta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Orden { get; set; }
    }
}
