using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SIstemaFarmaciaFinal.Models;

#nullable disable

namespace SIstemaFarmaciaFinal.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaMedicamento> CategoriaMedicamentos { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Laboratorio> Laboratorios { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<PresentacionMedicamento> PresentacionMedicamentos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; initial catalog=DbFarmacia; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CategoriaMedicamento>(entity =>
            {
                entity.Property(e => e.DescripcionCategoria).IsUnicode(false);

                entity.Property(e => e.NombreCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasOne(d => d.IdLaboratorioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Laboratorio");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Personal");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK_Detalle_Compras");

                entity.HasOne(d => d.CodComprasNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.CodCompras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Compras_Compras");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.Property(e => e.Cliente).IsUnicode(false);

                entity.HasOne(d => d.CodVentasNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.CodVentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_Venta_Ventas");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.Property(e => e.NombreComercial).IsUnicode(false);

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Compras");

                entity.HasOne(d => d.IdLaboratorioNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Laboratorio");

                entity.HasOne(d => d.IdPresentacionMedNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdPresentacionMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Presentacion_Medicamento");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.EmailLab).IsUnicode(false);

                entity.Property(e => e.NombreLaboratorio).IsUnicode(false);

                entity.Property(e => e.PoliticasDeVencimiento).IsUnicode(false);

                entity.Property(e => e.TelefonoLaboratorio).IsUnicode(false);
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.NombreGenerico).IsUnicode(false);

                entity.Property(e => e.ViaAdministracion).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicamentos_Categoria_Medicamento");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicamentos_Inventario");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.PrimerApellido).IsUnicode(false);

                entity.Property(e => e.SegundoApellido).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<PresentacionMedicamento>(entity =>
            {
                entity.Property(e => e.Concentracion).IsUnicode(false);

                entity.Property(e => e.FormaPresentacion).IsUnicode(false);

                entity.Property(e => e.SubUnidades).IsUnicode(false);

                entity.Property(e => e.UnidadEnvasado).IsUnicode(false);

                entity.Property(e => e.UnidadMedidaPresentacion).IsUnicode(false);

                entity.Property(e => e.Unidades).IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Inventario");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Personal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
