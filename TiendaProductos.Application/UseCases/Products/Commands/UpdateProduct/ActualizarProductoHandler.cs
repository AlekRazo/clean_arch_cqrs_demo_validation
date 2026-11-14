using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Application.Exceptions;
using TiendaProductos.Application.Utilities.Mediator;
using TiendaProductos.Domain.ValueObjects;

namespace TiendaProductos.Application.UseCases.Products.Commands.UpdateProduct;

public class ActualizarProductoHandler(IProductosRepository repositorio) : IRequestHandler<ActualizarProductoCommand>
{
    public async Task Handle(ActualizarProductoCommand comando)
    {
        var producto = await repositorio.ObtenerPorId(comando.Id);

        if (producto == null)
            throw new NotFoundException();

        var dinero = Dinero.Crear(comando.Precio, comando.Moneda);
        producto.Actualizar(comando.Nombre, comando.Descripcion, dinero, comando.Activo);

        await repositorio.Actualizar(producto);
    }
}
