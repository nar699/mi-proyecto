using mi_proyecto.Application.Interfaces;
using mi_proyecto.Application.Services;
using mi_proyecto.Infrastructure.Interfaces;
using mi_proyecto.Infrastructure.Persistence;
using mi_proyecto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Convierte la URL de Railway al formato que entiende Npgsql
var rawUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Default");

string connectionString;
if (rawUrl != null && rawUrl.StartsWith("postgresql://"))
{
    var uri = new Uri(rawUrl);
    var userInfo = uri.UserInfo.Split(':');
    connectionString = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
}
else
{
    connectionString = rawUrl!;
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IFormularioService, FormularioService>();
builder.Services.AddScoped<IFormularioRepository, FormularioRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowVercel", policy =>
        policy.WithOrigins("https://mi-formulario-chi.vercel.app")
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