using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            TblDepartamento = new HashSet<Department>();
            TblFestivos = new HashSet<Calendar>();
        }

        public int IdPais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Department> TblDepartamento { get; set; }
        public virtual ICollection<Calendar> TblFestivos { get; set; }
    }
}
