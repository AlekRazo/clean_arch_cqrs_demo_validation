using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Application.Exceptions;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Queries.GetProductById;

public class ObtenerProductoPorIdHandler(IProductosRepository repositorio) : IRequestHandler<ObtenerProductoPorIdQuery, ProductoDetalleDto>
{
    public async Task<ProductoDetalleDto> Handle(ObtenerProductoPorIdQuery request)
    {
        var producto = await repositorio.ObtenerPorId(request.Id);

        if (producto == null)
            throw new NotFoundException();

        //Mapeo de entidad a DTO
        return producto.ADto();
    }
}
