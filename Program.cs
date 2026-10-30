using Microsoft.EntityFrameworkCore;
using ApiEfCore.Context;
using ApiEfCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<miContextDb>(options => options.UseSqlite("Data Source=BaseDatos/mibase.db"));
builder.Services.AddScoped<IVehiculoService, VehiculoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
