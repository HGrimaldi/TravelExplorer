namespace Application.Destino.Update
{
    public record UpdateDestinoCommand(
        Guid Id,
        string Nombre,
        string Descripcion,
        string Ubicacion,
        bool Activo) : IRequest<ErrorOr<Unit>>;
}
