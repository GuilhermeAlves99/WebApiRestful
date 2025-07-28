using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApiRestful.Controllers;
using WebApiRestful.Data;
using WebApiRestful.DTOs;

var builder = WebApplication.CreateBuilder(args);

//Configuração do etity framework
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var productController = new ProductController();

app.MapGet("/products/{id:int}", (int id) =>
{
    var product = productController.GetProduct(id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});
app.MapPost("/products", (ProductResponse dto) =>
{
    if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null, true))
    {
        return Results.BadRequest("Dados inválidos.");
    }
    var product = productController.AddProduct(dto);
    return Results.Created($"/products/{product.Id}", product);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
