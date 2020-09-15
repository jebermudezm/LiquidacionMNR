using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblParametros
    {
        public int IdParametro { get; set; }
        public string CodigoParametro { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Valor { get; set; }
    }
}
