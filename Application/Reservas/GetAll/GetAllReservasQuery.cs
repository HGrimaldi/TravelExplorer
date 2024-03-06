using Reservas.Common;

namespace Application.Reservas.GetAll
{
    public record GetAllReservasQuery() : IRequest<ErrorOr<IReadOnlyList<ReservaResponse>>>;
}
