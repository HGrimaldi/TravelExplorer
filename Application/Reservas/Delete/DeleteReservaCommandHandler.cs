using Domain.Primitives;
using Domain.Reservas;

namespace Application.Reservas.Delete
{
    internal sealed class DeleteReservaCommandHandler : IRequestHandler<DeleteReservaCommand, ErrorOr<Unit>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReservaCommandHandler(IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteReservaCommand command, CancellationToken cancellationToken)
        {
            if (await _reservaRepository.GetByIdAsync(new ReservaId(command.Id)) is not Reserva reserva)
            {
                return Error.NotFound("Reserva.NotFound", "The reservation with the provided Id was not found.");
            }

            _reservaRepository.Delete(reserva);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
