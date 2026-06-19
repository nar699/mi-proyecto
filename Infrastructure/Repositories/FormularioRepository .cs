using mi_proyecto.Domain.Entities;
using mi_proyecto.Infrastructure.Interfaces;
using mi_proyecto.Infrastructure.Persistence;

namespace mi_proyecto.Infrastructure.Repositories
{
    public class FormularioRepository : IFormularioRepository
    {
        private readonly AppDbContext _context;

        public FormularioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task GuardarAsync(Formulario formulario)
        {
            await _context.Formularios.AddAsync(formulario);
            await _context.SaveChangesAsync();
        }
    }
}
