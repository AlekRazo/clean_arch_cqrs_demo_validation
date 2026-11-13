using System.ComponentModel.DataAnnotations;

namespace TiendaProductos.WebAPI.DTOs;

public class CrearProductoDto
{
    /*
     * Las anotaciones de datos son una forma sencilla de implementar validación de datos
     * sin la necesidad de revisar los campos directamente. También se puede validar mediante
     * FluentValidation u otras técnicas.
     */
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public required string Moneda { get; set; }
    public int InventarioInicial { get; set; }
}
