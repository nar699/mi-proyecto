using mi_proyecto.Application.Interfaces;
using mi_proyecto.Application.Services;
using mi_proyecto.Infrastructure;
using mi_proyecto.Infrastructure.Interfaces;
using mi_proyecto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Dependencias (D de SOLID — siempre interfaz → implementación)
builder.Services.AddScoped<IFormularioService, FormularioService>();
builder.Services.AddScoped<IFormularioRepository, FormularioRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowVercel", policy =>
        policy.WithOrigins("https://tu-app.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod()));

var app = builder.Build();
app.UseCors("AllowVercel");
app.MapControllers();
app.Run();