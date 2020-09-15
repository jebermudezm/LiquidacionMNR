using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblPais
    {
        public TblPais()
        {
            TblDepartamento = new HashSet<TblDepartamento>();
            TblFestivos = new HashSet<TblFestivos>();
        }

        public int IdPais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TblDepartamento> TblDepartamento { get; set; }
        public virtual ICollection<TblFestivos> TblFestivos { get; set; }
    }
}
