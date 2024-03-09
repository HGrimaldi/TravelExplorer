using Domain.Primitives;
using Domain.Reservas;

namespace Application.Reservas.Create
{
    internal sealed class CreateReservaCommandHandler : IRequestHandler<CreateReservaCommand, ErrorOr<Guid>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateReservaCommandHandler(IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateReservaCommand command, CancellationToken cancellationToken)
        {
            var reserva = new Reserva(
                new ReservaId(Guid.NewGuid()),
                command.IdPaquete,
                command.IdCliente,
                command.NombreCliente,
                command.EmailCliente,
                command.TelefonoCliente,
                command.FechaViaje
            );

            _reservaRepository.Add(reserva);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return reserva.Id.Value;
        }
    }
}
