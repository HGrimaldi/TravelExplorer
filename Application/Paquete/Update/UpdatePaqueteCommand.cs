namespace Application.Paquete.Update
{
    public record UpdatePaqueteCommand(
        Guid Id,
        string Nombre,
        string Descripcion,
        DateTime FechaInicio,
        DateTime FechaFin,
        decimal Precio,
        bool Activo) : IRequest<ErrorOr<Unit>>;
}