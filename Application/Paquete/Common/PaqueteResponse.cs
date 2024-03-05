namespace Customers.Common
{
    public record PaqueteResponse(
        Guid Id,
        string Nombre,
        string Descripcion,
        DateTime FechaInicio,
        DateTime FechaFin,
        decimal Precio,
        bool Activo
    );
}
