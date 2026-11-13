using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.Contracts;
using TiendaProductos.Infrastructure.Persistance;
using TiendaProductos.Infrastructure.Repositories;

namespace TiendaProductos.Infrastructure;

/*
 * Esta es una clase auxiliar para centralizar la inyección de dependencias de la infraestructura, pero
 * también se podría llamar directamente en TiendaProductos.API.Program.cs
 */
public static class InyeccionDeDependencia
{
    public static IServiceCollection AgregarInfraestructura(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer("name=DefaultConnection"));
        services.AddScoped<IProductosRepository, ProductosRepository>();

        return services;
    }
}
