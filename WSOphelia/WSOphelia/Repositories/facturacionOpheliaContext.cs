using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WSOphelia.Models;

namespace WSOphelia.Repositories
{
    public partial class facturacionOpheliaContext : DbContext
    {
        public facturacionOpheliaContext()
        {
        }

        public facturacionOpheliaContext(DbContextOptions<facturacionOpheliaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sqlserverophelia.database.windows.net;Database=facturacionOphelia;User=azureuser;Password=pru3b4.T3cn1c4#01");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("cliente_id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("Compra");

                entity.Property(e => e.CompraId)
                    .ValueGeneratedNever()
                    .HasColumnName("compra_id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FacturaId).HasColumnName("factura_id");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Factura");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Producto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("factura_id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("precioTotal");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("producto_id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("precio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
