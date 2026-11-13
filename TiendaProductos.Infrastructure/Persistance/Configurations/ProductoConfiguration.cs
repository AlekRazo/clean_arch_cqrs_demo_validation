using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Entities;

namespace TiendaProductos.Infrastructure.Persistance.Configurations;

/*
 * Para no sobrecargar DbContext se puede configurar las entidades de base de datos en clases
 * separadas. Para ello se utiliza la interfaz IEntityTypeConfiguration<T>
 */
internal class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(prop => prop.Nombre)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(prop => prop.Nombre).IsUnique();

        builder.Property(prop => prop.Description)
            .HasMaxLength(2000);

        builder.ComplexProperty(prop => prop.Precio, accion =>
        {
            accion.Property(p => p.Monto).HasColumnName("Precio").HasPrecision(18, 2);
            accion.Property(p => p.Moneda).HasColumnName("Moneda");
        });

        builder.ComplexProperty(prop => prop.CantidadInventario, accion =>
        {
            accion.Property(p => p.Valor).HasColumnName("Inventario");
        });
    }
}
