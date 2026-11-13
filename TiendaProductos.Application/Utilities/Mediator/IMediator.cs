using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Application.Utilities.Mediator;

/*
 * El patrón Mediador es un patrón de diseño en el cual se abstrae el caso de uso.
 * De la mano de CQRS es posible identificar qué caso de uso se necesita ejecutar
 * con base en el comando que recibe como parámetro.
 * 
 * El mediador se implementa en el controlador, por lo que disminuye el número de
 * parámetros del constructor de este al solo inyectar el mediador en lugar de cada
 * caso de uso.
 */
public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}
