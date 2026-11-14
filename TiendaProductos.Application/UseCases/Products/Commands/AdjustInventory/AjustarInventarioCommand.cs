using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Commands.AdjustInventory;

public record AjustarInventarioCommand(Guid IdProducto, int Delta) : IRequest;
