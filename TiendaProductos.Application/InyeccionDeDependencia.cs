using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Application.UseCases.Products.Commands.AdjustInventory;
using TiendaProductos.Application.UseCases.Products.Commands.CreateProduct;
using TiendaProductos.Application.UseCases.Products.Commands.UpdateProduct;
using TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;
using TiendaProductos.Application.UseCases.Products.Queries.GetProductById;
using TiendaProductos.Application.Utilities.Mediator;

namespace TiendaProductos.Application;

public static class InyeccionDeDependencia
{
    public static IServiceCollection AgregaAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();
        //AddScoped<Comando<ObjComando, ObjSalida>, CasoDeUso>();
        services.AddScoped<IRequestHandler<CrearProductoCommand, Guid>, CrearProductoHandler>();
        services.AddScoped<IRequestHandler<ActualizarProductoCommand>, ActualizarProductoHandler>();
        services.AddScoped<IRequestHandler<AjustarInventarioCommand>, AjustarInventarioHandler>();
        services.AddScoped<IRequestHandler<ObtenerProductoPorIdQuery, ProductoDetalleDto>, ObtenerProductoPorIdHandler>();
        services.AddScoped<IRequestHandler<FiltrarProductosQuery, List<ProductoFiltradoDto>>, FiltrarProductosHandler>();

        return services;
    }
}
