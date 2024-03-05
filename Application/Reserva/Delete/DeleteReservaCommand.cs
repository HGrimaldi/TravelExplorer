namespace Application.Reserva.Delete
{
    public record DeleteReservaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
