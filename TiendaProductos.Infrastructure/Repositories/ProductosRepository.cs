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
    public async Task Agregar(Producto producto)
    {
        context.Add(producto);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Existe(string nombre)
    {
        return await context.Productos.AnyAsync(x => x.Nombre == nombre);
    }
}