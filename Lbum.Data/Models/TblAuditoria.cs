using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblAuditoria
    {
        public long Id { get; set; }
        public short IdAccion { get; set; }
        public long IdEntidad { get; set; }
        public string EntidadAuditoria { get; set; }
        public string ObjetoEntidad { get; set; }
        public string Usuario { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TblAccion Accion { get; set; }
    }
}
