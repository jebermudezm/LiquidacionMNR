using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Calendar
    {
        public int IdFestivo { get; set; }
        public int IdPais { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Country IdPaisNavigation { get; set; }
    }
}
