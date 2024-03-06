using MediatR;
using Reservas.Common;

namespace Application.Reservas.GetAll
{
    public record GetAllReservasQuery : IRequest<List<ReservaResponse>>;
}
