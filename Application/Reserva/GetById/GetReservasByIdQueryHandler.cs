namespace Application.Reserva.GetById
{
    internal sealed class GetReservasByIdQueryHandler : IRequestHandler<GetReservaByIdQuery, ErrorOr<ReservaResponse>>
    {
        private readonly IReservaRepository _reservaRepository;

        public GetReservaByIdQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
        }

        public async Task<ErrorOr<ReservaResponse>> Handle(GetReservaByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _reservaRepository.GetByIdAsync(new ReservaId(query.Id)) is not Reserva reserva)
            {
                return Error.NotFound("Reserva.NotFound", "The reservation with the provided Id was not found.");
            }

            return new ReservaResponse(
                reserva.Id.Value,
                reserva.IdPaquete,
                reserva.NombreCliente,
                reserva.EmailCliente,
                reserva.TelefonoCliente,
                reserva.FechaViaje
            );
        }
    }
}
