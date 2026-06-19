using mi_proyecto.Domain.Entities;

namespace mi_proyecto.Infrastructure.Interfaces
{

    public interface IFormularioRepository
    {
        Task GuardarAsync(Formulario formulario);
    }
}
