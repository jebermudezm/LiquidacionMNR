using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lbum.Data.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Binnacle> TblBitacora { get; set; }
        public virtual DbSet<City> TblCiudad { get; set; }
        public virtual DbSet<Concept> TblConcepto { get; set; }
        public virtual DbSet<ConceptContrat> TblConceptoContrato { get; set; }
        public virtual DbSet<ConceptEnergyMeter> TblConceptoFrontera { get; set; }
        public virtual DbSet<ConceptMasterObjet> TblConceptoMaestroObjeto { get; set; }
        public virtual DbSet<ConsecutiveDocument> TblConsecutivoDocumento { get; set; }
        public virtual DbSet<Contrat> TblContrato { get; set; }
        public virtual DbSet<ContratEnergyMeter> TblContratoFrontera { get; set; }
        public virtual DbSet<Department> TblDepartamento { get; set; }
        public virtual DbSet<InvoiceDetail> TblDetalleFactura { get; set; }
        public virtual DbSet<Client> TblEmpresa { get; set; }
        public virtual DbSet<InvoiceHeader> TblEncabezadoFactura { get; set; }
        public virtual DbSet<Calendar> TblFestivos { get; set; }
        public virtual DbSet<EnergyMeter> TblFrontera { get; set; }
        public virtual DbSet<LiquidactionMaster> TblLiquidacion { get; set; }
        public virtual DbSet<ListMaster> TblListas { get; set; }
        public virtual DbSet<ListDetail> TblListasDetalle { get; set; }
        public virtual DbSet<MasterObjet> TblMaestroObjeto { get; set; }
        public virtual DbSet<Country> TblPais { get; set; }
        public virtual DbSet<Parameters> TblParametros { get; set; }
        public virtual DbSet<Profile> TblPerfil { get; set; }
        public virtual DbSet<Report> TblReporte { get; set; }
        public virtual DbSet<LiquidationDetail> TblResultadoLiquidacion { get; set; }
        public virtual DbSet<TypeConcept> TblTipoConcepto { get; set; }
        public virtual DbSet<User> TblUsuario { get; set; }
        public virtual DbSet<UserProfile> TblUsuarioPerfil { get; set; }
        public virtual DbSet<Version> TblVersion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=172.10.1.32\\sqldev2014;initial catalog=XMLFiles;user id=sa;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Binnacle>(entity =>
            {
                entity.HasKey(e => e.IdBitacora);

                entity.ToTable("tblBitacora", "MNR");

                entity.HasComment("Tabla para almacenar datos de la bitácora de ejecución");

                entity.Property(e => e.IdBitacora).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código de la bitácora que se quiera colocar, normalmente se coloca una abreviatura que  identifique el proceso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("Descripción del mensaje de bitácora");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasComment("Fechafinal de ejecución del proceso");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Inicial de ejecución del proceso");

                entity.Property(e => e.Version).HasComment("Versión del proceso que se está ejecutando");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.ToTable("tblCiudad", "MNR");

                entity.HasComment("Tabla para almacenar Ciudades");

                entity.Property(e => e.IdCiudad).HasComment("Identificador único autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código DANE de la ciudad");

                entity.Property(e => e.CodigoCentroPoblado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdDepartamento).HasComment("Identificador del Departamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre de la ciudad");

                entity.Property(e => e.NombreCentroPoblado)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.TblCiudad)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCiudad_tblDepartamento");
            });

            modelBuilder.Entity<Concept>(entity =>
            {
                entity.HasKey(e => e.IdConcepto)
                    .HasName("PK_tblConceptos");

                entity.ToTable("tblConcepto", "MNR");

                entity.HasComment("En esta tabla se define cada concepto que contenga valores periódicamente.");

                entity.Property(e => e.IdConcepto).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código que se le quiera dar al concepto.");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del concepto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre explicito del Concepto");

                entity.Property(e => e.NumeroMaterial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario de la aplicación que creó el concepto");
            });

            modelBuilder.Entity<ConceptContrat>(entity =>
            {
                entity.HasKey(e => e.IdConceptoContrato);

                entity.ToTable("tblConceptoContrato", "MNR");

                entity.Property(e => e.FechaBase).HasColumnType("datetime");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.TblConceptoContrato)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoContrato_tblConcepto");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TblConceptoContrato)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoContrato_tblContrato");
            });

            modelBuilder.Entity<ConceptEnergyMeter>(entity =>
            {
                entity.HasKey(e => e.IdConceptoFrontera);

                entity.ToTable("tblConceptoFrontera", "MNR");

                entity.HasComment("Tabla para asociar las frontearas a un contrato");

                entity.Property(e => e.IdConceptoFrontera).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasComment("Fecha del valor del concepto");

                entity.Property(e => e.Hora).HasComment("Hora para la cual se guarga el valor");

                entity.Property(e => e.IdConcepto).HasComment("Identificador del concepto");

                entity.Property(e => e.IdFrontera).HasComment("Identificador de la frontera");

                entity.Property(e => e.IdVersion).HasComment("Versión del proceso que se está ejecutando");

                entity.Property(e => e.Valor).HasComment("Valor del concepto");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.TblConceptoFrontera)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoFrontera_tblConceptos");

                entity.HasOne(d => d.IdFronteraNavigation)
                    .WithMany(p => p.TblConceptoFrontera)
                    .HasForeignKey(d => d.IdFrontera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoFrontera_tblFrontera");

                entity.HasOne(d => d.IdVersionNavigation)
                    .WithMany(p => p.TblConceptoFrontera)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoFrontera_tblVersion");
            });

            modelBuilder.Entity<ConceptMasterObjet>(entity =>
            {
                entity.HasKey(e => e.IdConceptoMaestroObjeto);

                entity.ToTable("tblConceptoMaestroObjeto", "MNR");

                entity.HasComment("Tabla para almacenar los valores asociados a objetos maestros");

                entity.Property(e => e.IdConceptoMaestroObjeto).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasComment("Fecha del valor del concepto");

                entity.Property(e => e.IdConcepto).HasComment("Identificador del concepto");

                entity.Property(e => e.IdMaestroObjeto).HasComment("Identificador del objeto Maestro");

                entity.Property(e => e.IdVersion).HasComment("Versión del proceso que se está ejecutando");

                entity.Property(e => e.Valor).HasComment("Valor del concepto");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.TblConceptoMaestroObjeto)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoMaestroObjeto_tblConceptos");

                entity.HasOne(d => d.IdMaestroObjetoNavigation)
                    .WithMany(p => p.TblConceptoMaestroObjeto)
                    .HasForeignKey(d => d.IdMaestroObjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoMaestroObjeto_tblMaestroObjeto");

                entity.HasOne(d => d.IdVersionNavigation)
                    .WithMany(p => p.TblConceptoMaestroObjeto)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoMaestroObjeto_tblVersion");
            });

            modelBuilder.Entity<ConsecutiveDocument>(entity =>
            {
                entity.HasKey(e => e.IdConsecutivoDocumento);

                entity.ToTable("tblConsecutivoDocumento", "MNR");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Prefijo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contrat>(entity =>
            {
                entity.HasKey(e => e.IdContrato);

                entity.ToTable("tblContrato", "MNR");

                entity.HasComment("Datos Básicos del contrato");

                entity.Property(e => e.IdContrato).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Código que se le quiera dar al Contrato.");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Descripción del contrato");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del contrato");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasComment("Fecha hasta donde el objeto está vigente, si está Null, se asume que es vigente indefinidamete");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasComment("Fecha a partir de la cual es vigente el contrato");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.TipoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPrecioBolsa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Fecha de creación del contrato");
            });

            modelBuilder.Entity<ContratEnergyMeter>(entity =>
            {
                entity.HasKey(e => e.IdContratoFrontera);

                entity.ToTable("tblContratoFrontera", "MNR");

                entity.HasComment("Tabla para asociar las frontearas a un contrato");

                entity.Property(e => e.IdContratoFrontera).HasComment("Identificador Autonumerico");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación de la asociación de la frontera al contrato");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasComment("Fecha hasta donde el objeto está vigente, si está Null, se asume que es vigente indefinidamete");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasComment("Fecha a partir de la cual es vigente el la asociación de la frontera al contrato");

                entity.Property(e => e.IdContrato).HasComment("Identificador del contrato");

                entity.Property(e => e.IdFrontera).HasComment("Identificador de la frontera");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario de la aplicación que creó el objeto");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TblContratoFrontera)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContratoFrontera_tblContrato");

                entity.HasOne(d => d.IdFronteraNavigation)
                    .WithMany(p => p.TblContratoFrontera)
                    .HasForeignKey(d => d.IdFrontera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContratoFrontera_tblFrontera");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("tblDepartamento", "MNR");

                entity.Property(e => e.IdDepartamento).HasComment("Identificador único autonumérico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Codigo DENE del departamento");

                entity.Property(e => e.IdPais).HasComment("Identificador del pais al cual pertenece el departamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del departamento");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.TblDepartamento)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDepartamento_tblPais");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("tblDetalleFactura", "MNR");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDetalle)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ValorIva).HasColumnName("ValorIVA");

                entity.HasOne(d => d.IdEncabezadoNavigation)
                    .WithMany(p => p.TblDetalleFactura)
                    .HasForeignKey(d => d.IdEncabezado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDetalleFactura_tblEncabezadoFactura");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("tblEmpresa", "MNR");

                entity.Property(e => e.IdEmpresa).HasComment("Identificador único Autonumerico");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Dirección de la empresa");

                entity.Property(e => e.IdCiiu).HasColumnName("IdCIIU");

                entity.Property(e => e.IdCiudad).HasComment("Id de la ciudad donde destá la empresa");

                entity.Property(e => e.IdInterno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código de la empresa o del agente que representa");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nit de la Empresa");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre o Razón social de la empresa");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Télefono de la empresa");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.TblEmpresa)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresa_tblCiudad");
            });

            modelBuilder.Entity<InvoiceHeader>(entity =>
            {
                entity.HasKey(e => e.IdEncabezado);

                entity.ToTable("tblEncabezadoFactura", "MNR");

                entity.Property(e => e.IdEncabezado).HasComment("Identificador único autonumerico");

                entity.Property(e => e.AjusteDecenaCreg100)
                    .HasColumnName("AjusteDecenaCREG100")
                    .HasComment("Valor de ajustes");

                entity.Property(e => e.CargaContratada).HasComment("Carga contratada");

                entity.Property(e => e.Circuito)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Circuito donde está la frontera");

                entity.Property(e => e.ClaseServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Clase de servicio (Industrial, residencial, etc)");

                entity.Property(e => e.CodigoFrontera)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoNiu)
                    .HasColumnName("CodigoNIU")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Código ");

                entity.Property(e => e.Cufe)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionCorrespondencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Dirección a donde se envia la correspondencia");

                entity.Property(e => e.DireccionEmisor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Dirección del emisor o empresa que emite la factura");

                entity.Property(e => e.DireccionInstalacion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Dirección de la frontera donde está instalado el servicio");

                entity.Property(e => e.Estado)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Estrato).HasComment("Estrato donde está instalado el servicio");

                entity.Property(e => e.FactorMedidorRespaldo).HasComment("Factor de energia activa");

                entity.Property(e => e.FacturasVencidas).HasComment("Facturas Vencidas");

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de expedición de la factura");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Fin del periodo de facturación");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Inicio del periodo de facturación");

                entity.Property(e => e.FechaSuspencion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de suspención en caso de no presentarse pago");

                entity.Property(e => e.FechaVencimientoConRecargo)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de vencimiento con recargo");

                entity.Property(e => e.FechaVencimientoSinRecargo)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de Vencimiento sin recargo");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Grupo al que pertenece la frontera");

                entity.Property(e => e.HorasInterrumpidasDes)
                    .HasColumnName("HorasInterrumpidasDES")
                    .HasComment("Numero de horas de interrupción");

                entity.Property(e => e.IdConsecutivo).HasComment("Prefijo de la factura");

                entity.Property(e => e.IdDepartamentoCorrespondencia).HasComment("Identificador del departamento donde se debe enviar la correspondencia");

                entity.Property(e => e.IdDepartamentoInstalacion).HasComment("Identificador del departamentdo donde está instlado el servicio");

                entity.Property(e => e.IdEmpresaReceptora).HasComment("Identificador de la empresa o cliente");

                entity.Property(e => e.IdInterno).HasComment("Numero interno de la factura");

                entity.Property(e => e.IdMunicipioCorrespondencia).HasComment("Identificador del municipio a donde se debe enviar la correspondencia");

                entity.Property(e => e.IdMunicipioInstalacion).HasComment("Identificador del municipio de instlación del servicio");

                entity.Property(e => e.IdOperadorRed).HasComment("Identificador del operador de Red");

                entity.Property(e => e.Ipp)
                    .HasColumnName("IPP")
                    .HasComment("Ipp del mes");

                entity.Property(e => e.MarcaMedidorPrincipal)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaMedidorRespaldo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Marca del medidor de energia activa");

                entity.Property(e => e.MesActiva).HasComment("Consumo histórico Energia Activa MEM");

                entity.Property(e => e.MesReactiva).HasComment("Consumo histórico Energia Reativa MEM");

                entity.Property(e => e.NitEmisor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Nit del emisor o empresa que emite la factura");

                entity.Property(e => e.NitEmpresaReceptora)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Nit del cliente o empresa receptora");

                entity.Property(e => e.NivelConexion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nivel de conexión de la frontera");

                entity.Property(e => e.NivelTension).HasComment("Nivel de tensión dónde está instlada la frontera");

                entity.Property(e => e.NombreDepartamentoCorrespondencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del departamento donde se debe enviar la correspondencia");

                entity.Property(e => e.NombreDepartamentoInstalacion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del departamento donde está instlado el servicio");

                entity.Property(e => e.NombreEmisor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del emisor o empresa que emite la factura");

                entity.Property(e => e.NombreEmpresaReceptora)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre de la empresa Receptora");

                entity.Property(e => e.NombreMunicipioCorrespondencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del municipio a donde se debe enviar la correspondencia");

                entity.Property(e => e.NombreMunicipioInstalacion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del municipio donde está instalado el servicio");

                entity.Property(e => e.NumeroInterrupcionesFes)
                    .HasColumnName("NumeroInterrupcionesFES")
                    .HasComment("Numero de interrupciones presentadas en el periodo");

                entity.Property(e => e.PorcentajeContribuciones).HasComment("Porcentaje de contribuciones");

                entity.Property(e => e.Prefijo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PromedioActiva).HasComment("Promedio energia Activa");

                entity.Property(e => e.PromedioReactiva).HasComment("Promedio energia Reactiva");

                entity.Property(e => e.PropietarioActivos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre del agente propietario de los activos");

                entity.Property(e => e.ReferenciaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Referencia de pago");

                entity.Property(e => e.ResolucionDianAutorretenedor)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Resolución DIAN dónde se indica si es autorretenedor");

                entity.Property(e => e.ResolucionDianRango)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Resolución DIAN donde se indica el Rango de numeración");

                entity.Property(e => e.ResolucionDianTipoContribuente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Resolución DIAN donde se indica el tipo de contribuyente");

                entity.Property(e => e.SerieMedidorPrincipal)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SerieMedidorRespaldo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Serie del medidor energia activa");

                entity.Property(e => e.Subestacion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Subestación a la cual pertenece la frontera");

                entity.Property(e => e.Subtotal).HasComment("Subtotal de la factura");

                entity.Property(e => e.Tarifa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Tarifa (Horaria, Diaria, Mensual, etc)");

                entity.Property(e => e.TasaMoraAplicada).HasComment("Tasa por intereses de mora");

                entity.Property(e => e.TelefonoCorrespondencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Tipo de Red");

                entity.Property(e => e.TotalOtrosCobros).HasComment("Total de otros cobros");

                entity.Property(e => e.ValorCu).HasComment("Valor del componente Cu de la tarifa");

                entity.Property(e => e.ValorD).HasComment("Valor del componente D de la tarifa");

                entity.Property(e => e.ValorG).HasComment("Valor del componente G de la tarifa");

                entity.Property(e => e.ValorPr).HasComment("Valor del componente Pr de la tarifa");

                entity.Property(e => e.ValorR).HasComment("Valor del componente R de la tarifa");

                entity.Property(e => e.ValorT).HasComment("Valor del componente T de la tarifa");

                entity.Property(e => e.ValorTotal).HasComment("Valor  total de la factura");

                entity.Property(e => e.ValorTrmipc)
                    .HasColumnName("ValorTRMIPC")
                    .HasComment("Valor del IPC en dolrares");

                entity.HasOne(d => d.IdConsecutivoNavigation)
                    .WithMany(p => p.TblEncabezadoFactura)
                    .HasForeignKey(d => d.IdConsecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEncabezadoFactura_tblConsecutivoDocumento");

                entity.HasOne(d => d.IdDepartamentoCorrespondenciaNavigation)
                    .WithMany(p => p.TblEncabezadoFactura)
                    .HasForeignKey(d => d.IdDepartamentoCorrespondencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEncabezadoFactura_tblDepartamento");

                entity.HasOne(d => d.IdEmpresaReceptoraNavigation)
                    .WithMany(p => p.TblEncabezadoFactura)
                    .HasForeignKey(d => d.IdEmpresaReceptora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEncabezadoFactura_tblEmpresa");

                entity.HasOne(d => d.IdFronteraNavigation)
                    .WithMany(p => p.TblEncabezadoFactura)
                    .HasForeignKey(d => d.IdFrontera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEncabezadoFactura_tblFrontera");

                entity.HasOne(d => d.IdMunicipioInstalacionNavigation)
                    .WithMany(p => p.TblEncabezadoFactura)
                    .HasForeignKey(d => d.IdMunicipioInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEncabezadoFactura_tblCiudad");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => e.IdFestivo);

                entity.ToTable("tblFestivos", "MNR");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.TblFestivos)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFestivos_tblPais");
            });

            modelBuilder.Entity<EnergyMeter>(entity =>
            {
                entity.HasKey(e => e.IdFrontera);

                entity.ToTable("tblFrontera", "MNR");

                entity.HasComment("Datos básicos de las fronteras");

                entity.Property(e => e.IdFrontera).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Circuito)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaseServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código de la frontera reistrado en XM.");

                entity.Property(e => e.CodigoPadre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("codigo padre para identificar las fronteras embebidas");

                entity.Property(e => e.DireccionCorrespondencia)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionInstalacion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaEvento)
                    .HasColumnType("datetime")
                    .HasComment("Fecha a partir de la cual es vigente el registro");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdd).HasColumnName("IdADD");

                entity.Property(e => e.IdMaestroObjetoAgnOr).HasColumnName("IdMaestroObjetoAgnOR");

                entity.Property(e => e.IdStr).HasColumnName("IdSTR");

                entity.Property(e => e.MarcaMedidorPrincipal)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaMedidorRespaldo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Niu)
                    .HasColumnName("NIU")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Niveltension).HasComment("Nivel de tensión al que está conectada la frontera");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre de la frontera");

                entity.Property(e => e.PagaContibucion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SerieMedidorPrincipal)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SerieMedidorRespaldo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Subestacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tarifa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCorrespondencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario de la aplicación que creó el registro");

                entity.HasOne(d => d.IdCiudadCorrespondenciaNavigation)
                    .WithMany(p => p.TblFrontera)
                    .HasForeignKey(d => d.IdCiudadCorrespondencia)
                    .HasConstraintName("FK_tblFrontera_tblCiudad");
            });

            modelBuilder.Entity<LiquidactionMaster>(entity =>
            {
                entity.HasKey(e => e.IdLiquidacion);

                entity.ToTable("tblLiquidacion", "MNR");

                entity.Property(e => e.IdLiquidacion).HasComment("Identificador único, valor autonumerico");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Estado de la liquidación(Preliminar, Aceptada, Facturada)");

                entity.Property(e => e.Factura)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Indica con Si, si la liquidación aplica para la factura de lo contrario con No");

                entity.Property(e => e.FechaAplica)
                    .HasColumnType("datetime")
                    .HasComment("Fecha para la cual aplica la liquidación en la factura, esto es mas que todo para reliquidaciones");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasComment("Fecha fin del periodo liquidado");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasComment("Fecha inicio del periodo liquidado");

                entity.Property(e => e.IdFrontera).HasComment("Identificador de la frontera llave foranea de la tabla tblFrontera");

                entity.Property(e => e.IdVersion).HasComment("Identificador de la versión con la cual se está liquidando.");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Tipo de liquidación, (PROVISION, PREPAGOS, LIQUIDACION, RELIQUIDACION)");

                entity.HasOne(d => d.IdFronteraNavigation)
                    .WithMany(p => p.TblLiquidacion)
                    .HasForeignKey(d => d.IdFrontera)
                    .HasConstraintName("FK_tblLiquidacion_tblFrontera");

                entity.HasOne(d => d.IdVersionNavigation)
                    .WithMany(p => p.TblLiquidacion)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLiquidacion_tblVersion");
            });

            modelBuilder.Entity<ListMaster>(entity =>
            {
                entity.HasKey(e => e.IdLista)
                    .HasName("PK_tblTablasSUI");

                entity.ToTable("tblListas", "MNR");

                entity.Property(e => e.IdLista).HasComment("Identificador único autonumérico.");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Código de la tabla.");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Nombre de la Tabla del SUI");
            });

            modelBuilder.Entity<ListDetail>(entity =>
            {
                entity.HasKey(e => e.IdListaDetalle)
                    .HasName("PK_tblRegistroTablasSUI");

                entity.ToTable("tblListasDetalle", "MNR");

                entity.Property(e => e.IdListaDetalle).HasComment("Identificador único de la tabla, valor autonumerico.");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Código del registro dado por el SUI");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.IdLista).HasComment("Campo para identificar los grupos de registros o tablas del SUI.");
            });

            modelBuilder.Entity<MasterObjet>(entity =>
            {
                entity.HasKey(e => e.IdMaestroObjeto);

                entity.ToTable("tblMaestroObjeto", "MNR");

                entity.HasComment("Almacena Información de objetos maestros generales, como STRs, ADDs, etc");

                entity.Property(e => e.IdMaestroObjeto).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código que se le quiera dar al objeto.");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del objeto");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasComment("Fecha hasta donde el objeto está vigente, si está Null, se asume que es vigente indefinidamete");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasComment("Fecha a partir de la cual es vigente el objeto");

                entity.Property(e => e.IdOrministerio)
                    .HasColumnName("IdORMinisterio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrsui)
                    .HasColumnName("IdORSUI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre explicito del objeto");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario de la aplicación que creó el objeto");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.ToTable("tblPais", "MNR");

                entity.HasComment("Tabla para almacenar los paises");

                entity.Property(e => e.IdPais).HasComment("Identificador Unico, autonumerico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código DANE del País");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre del país");
            });

            modelBuilder.Entity<Parameters>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.ToTable("tblParametros", "MNR");

                entity.HasComment("Tabla para configurar parametros de tal manera que no queden quemados en la aplicación");

                entity.Property(e => e.IdParametro).HasComment("Consecutivo único de la tabla, es autonumérico");

                entity.Property(e => e.CodigoParametro)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Final de vigencia del parametro");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Inicio de vigencia del parametro");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre para identificar el parametro");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasComment("Valor del parametro");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("tblPerfil", "MNR");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("tblReporte", "MNR");

                entity.Property(e => e.IdReporte).HasComment("Identificador consecutivo autonumerico y llave primaria de la tabla");

                entity.Property(e => e.Consulta)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasComment("Consulta con la que se genera el Reporte");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Descripción del reporte");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Fin de vigencia del reporte.");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Inicio de vigencia del reporte");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre del reporte con el cual se genera");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Tipo de reporte, AP: Archivo Plano, HE: Hoja de Excel");

                entity.Property(e => e.Titulos)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("Títulos de los encabezados del reporte, estos deben ir separados por punto y coma(;)");
            });

            modelBuilder.Entity<LiquidationDetail>(entity =>
            {
                entity.HasKey(e => e.IdResultadoLiquidacion);

                entity.ToTable("tblResultadoLiquidacion", "MNR");

                entity.HasComment("Tabla para almacenar los resultados de la liquidación");

                entity.HasIndex(e => e.Fecha)
                    .HasName("IDX_ResultadoLiquidacionFecha");

                entity.HasIndex(e => e.IdConcepto)
                    .HasName("IDX_ResultadoLiquidacionConcepto");

                entity.HasIndex(e => e.IdFrontera)
                    .HasName("IDX_ResultadoLiquidacionFrontera");

                entity.HasIndex(e => e.IdLiquidacion)
                    .HasName("IX_ResultadoLiquidacionIdLiquidacion");

                entity.Property(e => e.IdResultadoLiquidacion).HasComment("Identificador Autonumerico");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Factura)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasComment("Primer día del mes que se está liquidando");

                entity.Property(e => e.FechaAplica).HasColumnType("datetime");

                entity.Property(e => e.IdConcepto).HasComment("Identificador del concepto");

                entity.Property(e => e.IdContrato).HasComment("Identificador del contrato");

                entity.Property(e => e.IdVersion).HasComment("Versión segun versión de datos seleccionada al momento de liquidar");

                entity.Property(e => e.Texto)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasComment("Valor numérico si se requiere");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.TblResultadoLiquidacion)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblResultadoLiquidacion_tblConceptos");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TblResultadoLiquidacion)
                    .HasForeignKey(d => d.IdContrato)
                    .HasConstraintName("FK_tblResultadoLiquidacion_tblContrato");

                entity.HasOne(d => d.IdFronteraNavigation)
                    .WithMany(p => p.TblResultadoLiquidacion)
                    .HasForeignKey(d => d.IdFrontera)
                    .HasConstraintName("FK_tblResultadoLiquidacion_tblFrontera");

                entity.HasOne(d => d.IdMaestroNavigation)
                    .WithMany(p => p.TblResultadoLiquidacion)
                    .HasForeignKey(d => d.IdMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblResultadoLiquidacion_tblMaestroObjeto");

                entity.HasOne(d => d.IdVersionNavigation)
                    .WithMany(p => p.TblResultadoLiquidacion)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblResultadoLiquidacion_tblVersion");
            });

            modelBuilder.Entity<TypeConcept>(entity =>
            {
                entity.HasKey(e => e.IdTipoConcepto);

                entity.ToTable("tblTipoConcepto", "MNR");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("tblUsuario", "MNR");

                entity.HasComment("Tabla que se utilizará para la autenticación de usuarios");

                entity.Property(e => e.IdUsuario).HasComment("Identificador único de la tabla, es autonumérico");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Fin de vigencia del usuario");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasComment("Fecha Inicio de Vigencia del usuario.");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Nombre de usuario");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Usuario para la autenticación de la aplicación");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdPerfil });

                entity.ToTable("tblUsuarioPerfil", "MNR");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasKey(e => e.IdVersion);

                entity.ToTable("tblVersion", "MNR");

                entity.HasComment("Almacena las diferentes versiones de datos mitidas por XM (Tx1, Tx2, Txr, Txf, Tx3, …Txn) y su equivalente en número.");

                entity.Property(e => e.IdVersion).HasComment("Identificador Autonumerico");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del la versión");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasComment("Fecha hasta donde el objeto está vigente, si está Null, se asume que es vigente indefinidamete");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasComment("Fecha a partir de la cual es vigente el la versión");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario de la aplicación que creó la versión");

                entity.Property(e => e.VersionDatos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Versión de datos preconfigurada (Tx1, Tx2, Txr, Txf, Tx3, …Txn)");

                entity.Property(e => e.VesionNumerica).HasComment("Numero de versión qon la que se almacenará la información");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
