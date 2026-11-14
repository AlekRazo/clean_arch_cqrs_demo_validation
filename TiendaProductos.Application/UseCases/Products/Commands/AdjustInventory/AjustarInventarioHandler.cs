using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Application.Exceptions;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Commands.AdjustInventory;

public class AjustarInventarioHandler(IProductosRepository repositorio) : IRequestHandler<AjustarInventarioCommand>
{
    public async Task Handle(AjustarInventarioCommand request)
    {
        var producto = await repositorio.ObtenerPorId(request.IdProducto);

        if (producto is null)
            throw new NotFoundException();

        producto.AjustarInventario(request.Delta);
        await repositorio.Actualizar(producto);
    }
}
