namespace Application.Paquete.Create
{
    public record CreatePaqueteCommand(
        string Nombre,
        string Descripcion,
        DateTime FechaInicio,
        DateTime FechaFin,
        decimal Precio) : IRequest<ErrorOr<Guid>>;
}
