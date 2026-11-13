using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.UseCases.Products.Commands.CreateProduct;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application;

public static class InyeccionDeDependencia
{
    public static IServiceCollection AgregaAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();
        //AddScoped<Comando, CasoDeUso>();
        services.AddScoped<IRequestHandler<CrearProductoCommand, Guid>, CrearProductoHandler>();

        return services;
    }
}
