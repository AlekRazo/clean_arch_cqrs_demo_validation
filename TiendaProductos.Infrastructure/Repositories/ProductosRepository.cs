using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Domain.Entities;
using TiendaProductos.Infrastructure.Persistance;

namespace TiendaProductos.Infrastructure.Repositories;

internal class ProductosRepository(ApplicationDbContext context) : IProductosRepository
{
    public async Task Actualizar(Producto producto)
    {
        context.Update(producto);
        await context.SaveChangesAsync();
    }

    public async Task Agregar(Producto producto)
    {
        context.Add(producto);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Existe(string nombre)
    {
        return await context.Productos.AnyAsync(x => x.Nombre == nombre);
    }

    public async Task<List<Producto>> ObtenerFiltrado(string? nombre, bool? activo)
    {
        var queryable = context.Productos.AsQueryable();

        if (nombre is not null)
            queryable = queryable.Where(x => x.Nombre.Contains(nombre));

        if (activo is not null)
            queryable = queryable.Where(x => x.Activo == activo);

        return await queryable.ToListAsync();
    }

    public async Task<Producto?> ObtenerPorId(Guid id)
    {
        return await context.Productos.FirstOrDefaultAsync(x => x.Id == id);
    }
}