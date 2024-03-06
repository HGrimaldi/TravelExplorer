namespace Destinos.Common
{
    public record DestinoResponse(
        Guid Id,
        string Nombre,
        string Descripcion,
        string Ubicacion,
        bool Activo
    );
}