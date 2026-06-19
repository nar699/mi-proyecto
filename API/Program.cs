using mi_proyecto.Application.Interfaces;
using mi_proyecto.Application.Services;
using mi_proyecto.Infrastructure.Interfaces;
using mi_proyecto.Infrastructure.Persistence;
using mi_proyecto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IFormularioService, FormularioService>();
builder.Services.AddScoped<IFormularioRepository, FormularioRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowVercel", policy =>
        policy.WithOrigins("https://tu-app.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseCors("AllowVercel");
app.MapControllers();
app.Run();