namespace Application.Paquetes.Delete
{
    public record DeletePaqueteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
