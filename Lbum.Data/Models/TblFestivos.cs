using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblFestivos
    {
        public int IdFestivo { get; set; }
        public int IdPais { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TblPais IdPaisNavigation { get; set; }
    }
}
