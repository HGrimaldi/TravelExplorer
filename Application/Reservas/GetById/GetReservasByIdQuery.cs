using Reservas.Common;

namespace Application.Reservas.GetById
{
    public record GetReservasByIdQuery(Guid Id) : IRequest<ErrorOr<ReservaResponse>>;
}
