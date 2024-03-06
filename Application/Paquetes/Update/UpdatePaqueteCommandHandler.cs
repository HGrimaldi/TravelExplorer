using Domain.Paquetes;
using Domain.Primitives;

namespace Application.Paquetes.Update
{
    internal sealed class UpdatePaqueteCommandHandler : IRequestHandler<UpdatePaqueteCommand, ErrorOr<Unit>>
    {
        private readonly IPaqueteRepository _paqueteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaqueteCommandHandler(IPaqueteRepository paqueteRepository, IUnitOfWork unitOfWork)
        {
            _paqueteRepository = paqueteRepository ?? throw new ArgumentNullException(nameof(paqueteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdatePaqueteCommand command, CancellationToken cancellationToken)
        {
            if (!await _paqueteRepository.ExistsAsync(new PaqueteId(command.Id)))
            {
                return Error.NotFound("Paquete.NotFound", "The package with the provided Id was not found.");
            }

            var paquete = new Paquete(
                new PaqueteId(command.Id),
                command.Nombre,
                command.Descripcion,
                command.FechaInicio,
                command.FechaFin,
                command.Precio,
                command.Activo
            );

            _paqueteRepository.Update(paquete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
