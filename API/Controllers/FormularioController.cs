// MiApi.API/Controllers/FormularioController.cs
using mi_proyecto.Application.DTOs;
using mi_proyecto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace mi_proyecto.API.Controllers;

    [ApiController]
[Route("api/[controller]")]
public class FormularioController : ControllerBase
{
    private readonly IFormularioService _service;

    // Inyección de dependencias (D de SOLID)
    public FormularioController(IFormularioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Enviar([FromBody] FormularioDto dto)
    {
        var resultado = await _service.ProcesarAsync(dto);
        return Ok(resultado);
    }
}