using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblMaestroObjeto
    {
        public TblMaestroObjeto()
        {
            TblConceptoMaestroObjeto = new HashSet<TblConceptoMaestroObjeto>();
            TblResultadoLiquidacion = new HashSet<TblResultadoLiquidacion>();
        }

        public int IdMaestroObjeto { get; set; }
        public string Codigo { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdMercado { get; set; }
        public string IdOrsui { get; set; }
        public string IdOrministerio { get; set; }

        public virtual ICollection<TblConceptoMaestroObjeto> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<TblResultadoLiquidacion> TblResultadoLiquidacion { get; set; }
    }
}
