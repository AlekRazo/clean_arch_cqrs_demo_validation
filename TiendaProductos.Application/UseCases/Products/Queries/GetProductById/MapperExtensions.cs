using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Entities;

namespace TiendaProductos.Application.UseCases.Products.Queries.GetProductById;

internal static class MapperExtensions
{
    internal static ProductoDetalleDto ADto(this Producto producto)
    {
        return new ProductoDetalleDto
            (
            Id: producto.Id,
            Nombre: producto.Nombre,
            Descripcion: producto.Description!,
            Precio: producto.Precio.Monto,
            Moneda: producto.Precio.Moneda,
            Inventario: producto.CantidadInventario.Valor,
            Activo: producto.Activo
            );
    }
}
