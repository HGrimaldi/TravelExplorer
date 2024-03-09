using Domain.Reservas;
using Domain.Primitives;

namespace Application.Reservas.Update
{
    internal sealed class UpdateReservaCommandHandler : IRequestHandler<UpdateReservaCommand, ErrorOr<Unit>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReservaCommandHandler(IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateReservaCommand command, CancellationToken cancellationToken)
        {
            if (!await _reservaRepository.ExistsAsync(new ReservaId(command.Id)))
            {
                return Error.NotFound("Reserva.NotFound", "La reserva con el Id proporcionado no fue encontrada.");
            }

            var reserva = new Reserva(
                new ReservaId(command.Id),
                command.IdPaquete,
                command.IdCliente,
                command.NombreCliente,
                command.EmailCliente,
                command.TelefonoCliente,
                command.FechaViaje
            );

            _reservaRepository.Update(reserva);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
