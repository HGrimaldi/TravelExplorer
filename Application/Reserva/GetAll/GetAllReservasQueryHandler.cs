namespace Application.Reserva.GetAll
{
    internal sealed class GetAllReservasQueryHandler : IRequestHandler<GetAllReservasQuery, ErrorOr<IReadOnlyList<ReservaResponse>>>
    {
        private readonly IReservaRepository _reservaRepository;

        public GetAllReservasQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<ReservaResponse>>> Handle(GetAllReservasQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Reserva> reservas = await _reservaRepository.GetAll();

            return reservas.Select(reserva => new ReservaResponse(
                    reserva.Id.Value,
                    reserva.IdPaquete,
                    reserva.NombreCliente,
                    reserva.EmailCliente,
                    reserva.TelefonoCliente,
                    reserva.FechaViaje
                )).ToList();
        }
    }
}
