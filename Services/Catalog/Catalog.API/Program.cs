using Carter;
using Catalog.API.Data;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(a => a.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddCarter();

builder.Services.AddDbContext<CategoryContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.MapCarter();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.Run();


