using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblFrontera
    {
        public TblFrontera()
        {
            TblConceptoFrontera = new HashSet<TblConceptoFrontera>();
            TblContratoFrontera = new HashSet<TblContratoFrontera>();
            TblEncabezadoFactura = new HashSet<TblEncabezadoFactura>();
            TblLiquidacion = new HashSet<TblLiquidacion>();
            TblResultadoLiquidacion = new HashSet<TblResultadoLiquidacion>();
        }

        public int IdFrontera { get; set; }
        public string Codigo { get; set; }
        public string CodigoPadre { get; set; }
        public string Nombre { get; set; }
        public int Niveltension { get; set; }
        public int? IdEmpresa { get; set; }
        public double FactorPerdida { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Estado { get; set; }
        public string DireccionInstalacion { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdStr { get; set; }
        public int? IdAdd { get; set; }
        public int? IdMaestroObjetoAgnOr { get; set; }
        public string Subestacion { get; set; }
        public string Circuito { get; set; }
        public int? Estrato { get; set; }
        public string Grupo { get; set; }
        public string TipoRed { get; set; }
        public string MarcaMedidorPrincipal { get; set; }
        public string SerieMedidorPrincipal { get; set; }
        public double? FactorMedidorPrincipal { get; set; }
        public string MarcaMedidorRespaldo { get; set; }
        public string SerieMedidorRespaldo { get; set; }
        public double? FactorMedidorRespaldo { get; set; }
        public string Tarifa { get; set; }
        public string ClaseServicio { get; set; }
        public double? CargaContratada { get; set; }
        public string DireccionCorrespondencia { get; set; }
        public int? IdCiudadCorrespondencia { get; set; }
        public string TelefonoCorrespondencia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string PagaContibucion { get; set; }
        public string Niu { get; set; }
        public int? IdGrupoCalidad { get; set; }
        public int? IdUbicacion { get; set; }
        public int? IdSector { get; set; }
        public int? IdTipoTarifa { get; set; }
        public int? IdTipoLectura { get; set; }
        public int? IdSectorContribuyente { get; set; }
        public int? IdCargoInversion { get; set; }

        public virtual TblCiudad IdCiudadCorrespondenciaNavigation { get; set; }
        public virtual ICollection<TblConceptoFrontera> TblConceptoFrontera { get; set; }
        public virtual ICollection<TblContratoFrontera> TblContratoFrontera { get; set; }
        public virtual ICollection<TblEncabezadoFactura> TblEncabezadoFactura { get; set; }
        public virtual ICollection<TblLiquidacion> TblLiquidacion { get; set; }
        public virtual ICollection<TblResultadoLiquidacion> TblResultadoLiquidacion { get; set; }
    }
}
