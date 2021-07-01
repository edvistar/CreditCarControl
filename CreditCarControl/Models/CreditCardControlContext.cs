using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CreditCarControl.Models
{
    public partial class CreditCardControlContext : DbContext
    {
        public CreditCardControlContext()
        {
        }

        public CreditCardControlContext(DbContextOptions<CreditCardControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CreditCardControl;User ID=edvistar;Password=REIChelk22656626;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(50);

                entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.ToTable("detalle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pago");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PagoMinimo)
                    .HasColumnName("pagoMinimo")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PagoTotal)
                    .HasColumnName("pagoTotal")
                    .HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.ToTable("tarjeta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CupoAvance)
                    .HasColumnName("cupoAvance")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CupoDisponible)
                    .HasColumnName("cupoDisponible")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FechaCobro)
                    .HasColumnName("fechaCobro")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCorte)
                    .HasColumnName("fechaCorte")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.NumeroTarjeta)
                    .IsRequired()
                    .HasColumnName("numeroTarjeta")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
