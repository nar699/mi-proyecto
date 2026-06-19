using mi_proyecto.Application.DTOs;

namespace mi_proyecto.Application.Interfaces
{
    public interface IFormularioService
    {
        Task<FormularioResponseDto> ProcesarAsync(FormularioDto dto);
    }
}
