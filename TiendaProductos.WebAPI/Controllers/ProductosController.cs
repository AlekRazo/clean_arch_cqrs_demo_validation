using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
public class ProductosController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CrearProductoDto modelo)
    {
        throw new NotImplementedException();
    }
}
