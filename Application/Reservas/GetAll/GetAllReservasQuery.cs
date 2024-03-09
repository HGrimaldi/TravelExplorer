using Reservas.Common;
using System.Collections.Generic;

namespace Application.Reservas.GetAll
{
    public record GetAllReservasQuery() : IRequest<ErrorOr<IReadOnlyList<ReservaResponse>>>;
}
