using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Commands.CreateProduct;

/*
 * El comando debe implementar IRequest para poder utilizado por el mediador
 * junto con el tipo de dato de salida deseado. Los tipos del comando, así como 
 * de la salida (Especificado en IRequest) deben coincidir con los tipos de dato
 * del caso de uso (o el Handler)
 */
public record CrearProductoCommand
(
    string Nombre,
    string? Descripcion,
    decimal Precio,
    string Moneda,
    int InventarioInicial
) : IRequest<Guid>;
