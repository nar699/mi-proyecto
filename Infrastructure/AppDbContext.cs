using mi_proyecto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace mi_proyecto.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Formulario> Formularios => Set<Formulario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(f => f.Email).IsRequired().HasMaxLength(200);
                entity.Property(f => f.FechaEnvio).IsRequired();
            });
        }
    }
}
