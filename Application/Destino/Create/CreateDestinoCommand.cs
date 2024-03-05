namespace Application.Destino.Create
{
    public record CreateDestinoCommand(
        string Nombre,
        string Descripcion,
        string Ubicacion) : IRequest<ErrorOr<Guid>>;
}
