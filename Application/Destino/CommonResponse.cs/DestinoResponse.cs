namespace Customers.Common
{
    public record DestinoResponse(
        Guid Id,
        string Nombre,
        string Descripcion,
        string Ubicacion,
        bool Activo
    );
}