namespace Application.Reserva.GetAll
{
    public record GetAllReservasQuery() : IRequest<ErrorOr<IReadOnlyList<ReservaResponse>>>;
}
