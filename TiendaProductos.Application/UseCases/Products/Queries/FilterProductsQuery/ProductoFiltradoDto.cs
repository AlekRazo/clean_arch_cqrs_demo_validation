using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;

public record ProductoFiltradoDto(Guid Id, string Nombre, decimal Precio, string Moneda);
