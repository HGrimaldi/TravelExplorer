namespace Application.Reserva.GetById
{
    public record GetReservasByIdQuery(Guid Id) : IRequest<ErrorOr<ReservaResponse>>;
}
