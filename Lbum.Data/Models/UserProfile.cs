using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class UserProfile
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
