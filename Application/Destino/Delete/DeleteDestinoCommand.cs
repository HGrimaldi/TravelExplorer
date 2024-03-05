namespace Application.Destino.Delete
{
    public record DeleteDestinoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
