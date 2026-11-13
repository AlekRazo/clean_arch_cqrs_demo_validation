using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Domain.Entities;
using TiendaProductos.Domain.Exceptions;
using TiendaProductos.Domain.ValueObjects;

namespace TiendaProductos.Application.UseCases.Products.Commands.CreateProduct;

/*
 * En el patrón CQRS las operaciones se dividen en comandos (Command) y consultas (Query)
 * Los comandos comprenden de las siguientes partes:
 * - El objeto de entrada
 * - El manejador del evento (el caso de uso per se)
 * - El validador de datos
 */
public class CrearProductoHandler(IProductosRepository repositorioProductos)
{
    public async Task<Guid> Handle(CrearProductoCommand comando)
    {
        var existe = await repositorioProductos.Existe(comando.Nombre);

        //En lugar de implementar excepciones se pueden utilizar patrones de diseño.
        if (existe)
            throw new BusinessRuleException($"Ya existe un producto con el nombre: {comando.Nombre}.");

        var dinero = Dinero.Crear(comando.Precio, comando.Moneda);
        var inventario = CantidadInventario.Crear(comando.InventarioInicial);

        var producto = Producto.Crear(
            nombre: comando.Nombre,
            descripcion: comando.Descripcion,
            precio: dinero,
            inventario: inventario
        );

        await repositorioProductos.Agregar(producto);
        return producto.Id;
    }
}
