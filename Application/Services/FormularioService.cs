using mi_proyecto.Application.DTOs;
using mi_proyecto.Application.Interfaces;
using mi_proyecto.Domain.Entities;
using mi_proyecto.Infrastructure.Interfaces;

namespace mi_proyecto.Application.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IFormularioRepository _repo;

        public FormularioService(IFormularioRepository repo)
        {
            _repo = repo;
        }

        public async Task<FormularioResponseDto> ProcesarAsync(FormularioDto dto)
        {
            var formulario = Formulario.Crear(dto.Nombre, dto.Email);
            await _repo.GuardarAsync(formulario);
            return new FormularioResponseDto(formulario.Id, "Guardado correctamente");
        }
    }
}
