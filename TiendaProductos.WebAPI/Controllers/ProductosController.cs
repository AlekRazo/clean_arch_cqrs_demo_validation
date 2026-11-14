using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaProductos.Application.UseCases.Products.Commands.AdjustInventory;
using TiendaProductos.Application.UseCases.Products.Commands.CreateProduct;
using TiendaProductos.Application.UseCases.Products.Commands.UpdateProduct;
using TiendaProductos.Application.UseCases.Products.Queries.FilterProductsQuery;
using TiendaProductos.Application.UseCases.Products.Queries.GetProductById;
using TiendaProductos.Application.Utilities.Mediator;
using TiendaProductos.WebAPI.DTOs;

namespace TiendaProductos.WebAPI.Controllers;

/*
 * Mientras crece la API y se agregan más casos de uso, el controlador también debe inyectar cada
 * caso de uso, esto provoca que el constructor se haga demasiado grande y difícil de leer.
 * 
 * Una solución es el patrón mediador que va de la mano con el patrón CQRS
 */
[Route("api/productos")]
[ApiController]
public class ProductosController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDetalleDto>> Get(Guid id)
    {
        var consulta = new ObtenerProductoPorIdQuery(Id: id);
        return await mediator.Send(consulta);
    }

    [HttpGet("filtrado")]
    public async Task<ActionResult<List<ProductoFiltradoDto>>> GetFiltrado(string? nombre, bool? activo)
    {
        var consulta = new FiltrarProductosQuery(nombre, activo);
        return await mediator.Send(consulta);
    }

    /*
     * Se crea el comando a partir del DTO y se utiliza como parámetro en el método Send.
     * El mediador se encarga de invocar el caso de uso correspondiente.
     */
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CrearProductoDto modelo)
    {
        var comando = new CrearProductoCommand
            (
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion,
            Precio: modelo.Precio,
            Moneda: modelo.Moneda,
            InventarioInicial: modelo.InventarioInicial
            );
        var id = await mediator.Send(comando);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ActualizarProductoDto modelo)
    {
        var comando = new ActualizarProductoCommand
            (
            Id: id,
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion,
            Precio: modelo.Precio,
            Moneda: modelo.Moneda,
            Activo: modelo.Activo
            );

        await mediator.Send(comando);
        return NoContent();
    }

    [HttpPost("{id}/inventario")]
    public async Task<ActionResult> AdjustInventory(Guid id, [FromBody] AjustInventarioDto modelo)
    {
        var comando = new AjustarInventarioCommand
            (
            IdProducto: id,
            Delta: modelo.Delta
            );

        await mediator.Send(comando);
        return NoContent();
    }
}
