using Domain.Reservas;
using Reservas.Common;
using System;

namespace Application.Reservas.GetById
{
    internal sealed class GetReservasByIdQueryHandler : IRequestHandler<GetReservasByIdQuery, ErrorOr<ReservaResponse>>
    {
        private readonly IReservaRepository _reservaRepository;

        public GetReservasByIdQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
        }

        public async Task<ErrorOr<ReservaResponse>> Handle(GetReservasByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _reservaRepository.GetByIdAsync(new ReservaId(query.Id)) is not Reserva reserva)
            {
                return Error.NotFound("Reserva.NotFound", "The reservation with the provided Id was not found.");
            }

            return new ReservaResponse(
                reserva.Id.Value,
                reserva.IdPaquete.Value, // Acceder al valor de PaqueteId
                reserva.NombreCliente,
                reserva.EmailCliente,
                reserva.TelefonoCliente,
                reserva.FechaViaje
            );
        }
    }
}
