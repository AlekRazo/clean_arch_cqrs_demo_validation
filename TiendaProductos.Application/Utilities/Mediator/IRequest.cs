using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Application.Utilities.Mediator;

/*
 * IRequest puede representar tanto un comando como una consulta.
 * Esta representación de una petición incluye el objeto de salida de esta petición.
 */
public interface IRequest<TResponse>
{
}

//Comando que recibe un parámetro, pero no retorna nada
public interface IRequest
{
}

/*
 * El Handler representa la lógica del caso de uso de la petición.
 * El Handler recibe como parámetro el comando bajo IRequest y el objeto de respuesta como salida.
 */
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}

public interface IRequestHandler<TRequest>
{
    Task Handle(TRequest request);
}