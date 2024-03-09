using Reservas.Common;
using System;

namespace Application.Reservas.GetById
{
    public record GetReservasByIdQuery(Guid Id) : IRequest<ErrorOr<ReservaResponse>>;
}