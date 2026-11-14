using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Entities;

namespace TiendaProductos.Application.Contracts;

public interface IProductosRepository
{
    Task Agregar(Producto producto);
    Task<bool> Existe(string nombre);
    Task<Producto?> ObtenerPorId(Guid id);
    Task Actualizar(Producto producto);
    Task<List<Producto>> ObtenerFiltrado(string? nombre, bool? activo);
}
