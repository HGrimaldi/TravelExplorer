namespace Application.Paquete.Delete
{
    public record DeletePaqueteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
