using Domain.Destinos;
using Domain.Primitives;

namespace Application.Destinos.Update
{
    internal sealed class UpdateDestinoCommandHandler : IRequestHandler<UpdateDestinoCommand, ErrorOr<Unit>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateDestinoCommandHandler(IDestinoRepository destinoRepository, IUnitOfWork unitOfWork)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Unit>> Handle(UpdateDestinoCommand command, CancellationToken cancellationToken)
        {
            if (!await _destinoRepository.ExistsAsync(new DestinoId(command.Id)))
            {
                return Error.NotFound("Destino.NotFound", "The destination with the provided Id was not found.");
            }

            Destino destino = await _destinoRepository.GetByIdAsync(new DestinoId(command.Id));
            destino.Update(
                command.Nombre,
                command.Descripcion,
                command.Ubicacion,
                command.Activo
            );

            _destinoRepository.Update(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
