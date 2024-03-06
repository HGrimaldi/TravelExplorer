namespace Application.Reservas.Delete
{
    public record DeleteReservaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
