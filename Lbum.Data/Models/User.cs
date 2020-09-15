using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class User
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
