using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Entities;

namespace TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;

internal static class MapperExtensions
{
    internal static ProductoFiltradoDto ADto(this Producto producto)
    {
        return new ProductoFiltradoDto
            (
            Id: producto.Id,
            Nombre: producto.Nombre,
            Precio: producto.Precio.Monto,
            Moneda: producto.Precio.Moneda
            );
    }
}
