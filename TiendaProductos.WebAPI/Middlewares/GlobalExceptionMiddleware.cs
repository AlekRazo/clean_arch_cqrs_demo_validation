using System.Net;
using System.Text.Json;
using TiendaProductos.Application.Exceptions;
using TiendaProductos.Domain.Exceptions;

namespace TiendaProductos.WebAPI.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    /*
     * Manejador de errores. También se podría colocar dentro del catch
     */
    private Task HandleException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var resultado = string.Empty;

        switch(exception)
        {
            case BusinessRuleException businessRuleException:
                httpStatusCode = HttpStatusCode.BadRequest;
                resultado = JsonSerializer.Serialize(businessRuleException.Message);
                break;

            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
        }
        
        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);
    }
}
public static class ExceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UserExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}