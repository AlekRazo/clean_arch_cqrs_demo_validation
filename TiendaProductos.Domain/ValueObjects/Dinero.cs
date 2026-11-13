using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Exceptions;

namespace TiendaProductos.Domain.ValueObjects;

/*
 * Una entidad y un objecto de valor se diferencian en que las entidades tienen una identidad
 * o una forma de identificarse del resto de objetos de su tipo, mientras los objetos de valor
 * no tienen identidad y comúnmente describen valores calculados, mas no propiedades.
 */

/*
 * Las entidades y objetos de valor implementan el Diseño Orientado a Dominio 
 * (DDD o Domain-Driven Design) donde las entidades incluyen parte de la lógica de negocio
 */

public class Dinero
{
    /*
     * El constructor y setters privados ayudan a proporcionar control sobre la
     * asignación de valores a las propiedades del objeto evitando saltar las reglas
     * de negocio e implementar valores arbitrarios a estos.
     */
    public decimal Monto { get; private set; }
    public string Moneda { get; private set; } = default;

    private Dinero(decimal monto, string moneda)
    {
        Monto = monto;
        Moneda = moneda;
    }

    /*
     * En lugar de utilizar los constructores y setters directamente se utilizan métodos
     * que se encargarán de crear los objetos y controlar qué propiedades se pueden 
     * manipular y qué valores admiten estos.
     */

    public static Dinero Crear(decimal monto, string moneda = "USD")
    {
        // Invariantes de negocio
        //(Ver patrón resultado) se pueden crear excepciones personalizadas o utilizar el patrón resultado.
        if (monto < 0)
            throw new BusinessRuleException("El monto no puede ser negativo.");

        if (string.IsNullOrEmpty(moneda))
            throw new BusinessRuleException("La moneda es requerida");

        return new Dinero(monto, moneda);
    }
}
