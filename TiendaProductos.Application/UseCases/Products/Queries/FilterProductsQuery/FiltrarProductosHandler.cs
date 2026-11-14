using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Application.Utilities.Mediator;
using TiendaProductos.Domain.Entities;

namespace TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;

public class FiltrarProductosHandler(IProductosRepository repositorio) : IRequestHandler<FiltrarProductosQuery, List<ProductoFiltradoDto>>
{
    public async Task<List<ProductoFiltradoDto>> Handle(FiltrarProductosQuery request)
    {
        List<Producto> productos = await repositorio.ObtenerFiltrado(request.Nombre, request.Activo);
        var productosDto = productos.Select(producto => producto.ADto()).ToList();
        
        return productosDto;
    }
}
