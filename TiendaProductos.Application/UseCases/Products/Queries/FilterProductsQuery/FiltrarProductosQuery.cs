using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;

public record FiltrarProductosQuery(string? Nombre, bool? Activo) : IRequest<List<ProductoFiltradoDto>>;
