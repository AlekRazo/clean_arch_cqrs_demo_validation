using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Commands.UpdateProduct;

/*
 * El comando debe implementar IRequest para poder utilizado por el mediador
 * junto con el tipo de dato de salida deseado.
 * 
 * Existen casos de uso donde no se espera un valor de retorno, por lo que se
 * puede utiliar un IRequest más simple.
 */
public record ActualizarProductoCommand
    (
    Guid Id,
    string Nombre,
    string? Descripcion,
    decimal Precio,
    string Moneda,
    bool Activo) : IRequest;
