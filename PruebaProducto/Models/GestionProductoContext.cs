using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaProducto.Models;

public partial class GestionProductoContext : DbContext
{
    
    public GestionProductoContext()
    {
    }

    public GestionProductoContext(DbContextOptions<GestionProductoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1166A283A");

            entity.ToTable("Estado");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Descripcion");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.IdImg).HasName("PK__Imagen__0C1AF99B0BBEFF2D");

            entity.ToTable("Imagen");

            entity.Property(e => e.Extension)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210DC2FE2DF");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.oEstado).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("fk_estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
