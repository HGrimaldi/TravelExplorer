namespace Application.Reserva.Update
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
                return Error.NotFound("Reserva.NotFound", "The reservation with the provided Id was not found.");
            }

            var reserva = await _reservaRepository.GetByIdAsync(new ReservaId(command.Id));
            reserva.Update(command.NombreCliente, command.EmailCliente, command.TelefonoCliente, command.FechaViaje);

            _reservaRepository.Update(reserva);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
