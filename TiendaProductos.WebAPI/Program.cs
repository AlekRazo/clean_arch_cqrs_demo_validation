using TiendaProductos.Application;
using TiendaProductos.Infrastructure;
using TiendaProductos.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Aquí se llaman los servicios de Infrastructure.
builder.Services.AgregarInfraestructura().AgregaAplicacion();

var app = builder.Build();

app.UserExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
