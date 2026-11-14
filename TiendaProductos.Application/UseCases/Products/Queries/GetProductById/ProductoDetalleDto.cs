using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Application.UseCases.Products.Queries.GetProductById;

public record ProductoDetalleDto
    (
    Guid Id,
    string Nombre,
    string Descripcion,
    decimal Precio,
    string Moneda,
    int Inventario,
    bool Activo
    );
