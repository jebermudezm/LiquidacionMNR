
namespace Lbum.Data.Models
{
    using Base;
    using System.Collections.Generic;
    public partial class TblAccion
    {
        public TblAccion()
        {
            TblAuditoria = new HashSet<TblAuditoria>();
        }

        public string Nombre { get; set; }

        public ICollection<TblAuditoria> TblAuditoria { get; set; }
    }
}
