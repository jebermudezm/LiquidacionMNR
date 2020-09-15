using System;
using System.Collections.Generic;

namespace Lbum.Data.Models
{
    public partial class TblEncabezadoFactura
    {
        public TblEncabezadoFactura()
        {
            TblDetalleFactura = new HashSet<TblDetalleFactura>();
        }

        public int IdEncabezado { get; set; }
        public int IdInterno { get; set; }
        public int IdConsecutivo { get; set; }
        public string Prefijo { get; set; }
        public int? Numero { get; set; }
        public int IdEmpresaReceptora { get; set; }
        public string NitEmpresaReceptora { get; set; }
        public string NombreEmpresaReceptora { get; set; }
        public string DireccionInstalacion { get; set; }
        public int IdMunicipioInstalacion { get; set; }
        public string NombreMunicipioInstalacion { get; set; }
        public int IdDepartamentoInstalacion { get; set; }
        public string NombreDepartamentoInstalacion { get; set; }
        public string DireccionCorrespondencia { get; set; }
        public int? IdMunicipioCorrespondencia { get; set; }
        public string NombreMunicipioCorrespondencia { get; set; }
        public int IdDepartamentoCorrespondencia { get; set; }
        public string NombreDepartamentoCorrespondencia { get; set; }
        public string TelefonoCorrespondencia { get; set; }
        public string ReferenciaPago { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaVencimientoSinRecargo { get; set; }
        public DateTime? FechaVencimientoConRecargo { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaSuspencion { get; set; }
        public int? FacturasVencidas { get; set; }
        public double? NumeroInterrupcionesFes { get; set; }
        public double? HorasInterrumpidasDes { get; set; }
        public double? ValorTrmipc { get; set; }
        public double? TasaMoraAplicada { get; set; }
        public double? Ipp { get; set; }
        public double? TotalOtrosCobros { get; set; }
        public double? Subtotal { get; set; }
        public double? AjusteDecenaCreg100 { get; set; }
        public double? ValorTotal { get; set; }
        public int IdFrontera { get; set; }
        public string CodigoFrontera { get; set; }
        public string ClaseServicio { get; set; }
        public double? CargaContratada { get; set; }
        public int? Estrato { get; set; }
        public string Subestacion { get; set; }
        public string Tarifa { get; set; }
        public string Grupo { get; set; }
        public string Circuito { get; set; }
        public string CodigoNiu { get; set; }
        public int? IdOperadorRed { get; set; }
        public double? MesActiva { get; set; }
        public double? MesReactiva { get; set; }
        public double? PromedioActiva { get; set; }
        public double? PromedioReactiva { get; set; }
        public double? ValorG { get; set; }
        public double? ValorC { get; set; }
        public double? ValorT { get; set; }
        public double? ValorD { get; set; }
        public double? ValorPr { get; set; }
        public double? ValorR { get; set; }
        public double? ValorCu { get; set; }
        public double? PorcentajeContribuciones { get; set; }
        public double? TarifaContribuciones { get; set; }
        public double? ValorContribuciones { get; set; }
        public int? NivelTension { get; set; }
        public string TipoRed { get; set; }
        public string PropietarioActivos { get; set; }
        public string NivelConexion { get; set; }
        public string MarcaMedidorPrincipal { get; set; }
        public string SerieMedidorPrincipal { get; set; }
        public double? FactorMedidorPrincipal { get; set; }
        public string MarcaMedidorRespaldo { get; set; }
        public string SerieMedidorRespaldo { get; set; }
        public double? FactorMedidorRespaldo { get; set; }
        public string NitEmisor { get; set; }
        public string NombreEmisor { get; set; }
        public string DireccionEmisor { get; set; }
        public string ResolucionDianTipoContribuente { get; set; }
        public string ResolucionDianAutorretenedor { get; set; }
        public string ResolucionDianRango { get; set; }
        public string Estado { get; set; }
        public string Cufe { get; set; }
        public int? DiasMora { get; set; }

        public virtual TblConsecutivoDocumento IdConsecutivoNavigation { get; set; }
        public virtual TblDepartamento IdDepartamentoCorrespondenciaNavigation { get; set; }
        public virtual TblEmpresa IdEmpresaReceptoraNavigation { get; set; }
        public virtual TblFrontera IdFronteraNavigation { get; set; }
        public virtual TblCiudad IdMunicipioInstalacionNavigation { get; set; }
        public virtual ICollection<TblDetalleFactura> TblDetalleFactura { get; set; }
    }
}
