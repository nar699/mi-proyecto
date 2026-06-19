namespace mi_proyecto.Application.DTOs
{
    public record FormularioDto(
    string Nombre,
    string Email,
    string? Mensaje
);

    public record FormularioResponseDto(
        Guid Id,
        string Mensaje
    );
}
