using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Domain.Exceptions;

namespace TiendaProductos.Domain.ValueObjects;

public class CantidadInventario
{
    public int Valor { get; private set; }

    private CantidadInventario(int valor) => Valor = valor;

    public static CantidadInventario Crear(int valor)
    {
        if (valor < 0)
            throw new BusinessRuleException("El inventario no puede ser negativo");

        return new CantidadInventario(valor);
    }
}
