using TiendaProductos.Domain.Exceptions;
using TiendaProductos.Domain.ValueObjects;

namespace TiendaProductos.Domain.Entities;

/*
 * Las entidades y objetos de valor implementan el Diseño Orientado a Dominio 
 * (DDD o Domain-Driven Design) donde las entidades incluyen parte de la lógica de negocio
 */
public class Producto
{
    /*
     * El constructor y setters privados ayudan a proporcionar control sobre la
     * asignación de valores a las propiedades del objeto evitando saltar las reglas
     * de negocio e implementar valores arbitrarios a estos.
     */
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Nombre { get; private set; } = default!;
    public string? Description { get; private set; }
    public Dinero Precio { get; private set; } = Dinero.Crear(0);
    public CantidadInventario CantidadInventario { get; private set; } = CantidadInventario.Crear(0);
    public bool Activo { get; private set; } = true;

    /*
     * En lugar de utilizar los constructores y setters directamente se utilizan métodos
     * que se encargarán de crear los objetos y controlar qué propiedades se pueden 
     * manipular y qué valores admiten estos.
     */

    public static Producto Crear(string nombre, string? descripcion, Dinero precio, CantidadInventario inventario)
    {
        /*En caso de cumplirse alguna condición se lanza una excepción. El costo de rendimiento de las excepciones
         * es alto, pero este es un último recurso, antes de llegar a este punto ya se han implementado otras
         * soluciones de validación de datos y rara vez se llega a este punto.
         */
        if (string.IsNullOrEmpty(nombre))
            throw new BusinessRuleException("El nombre del producto es requerido.");

        if (nombre.Trim().Length > 200)
            throw new BusinessRuleException("La longitud máxima del nombre es de 200 caracteres.");

        return new Producto
        {
            Nombre = nombre,
            Description = descripcion,
            Precio = precio,
            CantidadInventario = inventario
        };
    }
}
