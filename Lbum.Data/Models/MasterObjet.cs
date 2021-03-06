﻿using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class MasterObjet
    {
        public MasterObjet()
        {
            TblConceptoMaestroObjeto = new HashSet<ConceptMasterObjet>();
            TblResultadoLiquidacion = new HashSet<LiquidationDetail>();
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

        public virtual ICollection<ConceptMasterObjet> TblConceptoMaestroObjeto { get; set; }
        public virtual ICollection<LiquidationDetail> TblResultadoLiquidacion { get; set; }
    }
}
