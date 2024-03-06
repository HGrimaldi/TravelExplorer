namespace Application.Destinos.Delete
{
    public record DeleteDestinoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
