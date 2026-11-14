using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Queries.GetProductById;

public record ObtenerProductoPorIdQuery(Guid Id) : IRequest<ProductoDetalleDto>; 
