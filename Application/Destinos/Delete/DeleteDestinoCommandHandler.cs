using Domain.Destinos;
using Domain.Primitives;
using Domain.ValueObjects;
using Domain.DomainErrors;

namespace Application.Destinos.Delete
{
    internal sealed class DeleteDestinoCommandHandler : IRequestHandler<DeleteDestinoCommand, ErrorOr<Unit>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteDestinoCommandHandler(IDestinoRepository destinoRepository, IUnitOfWork unitOfWork)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Unit>> Handle(DeleteDestinoCommand command, CancellationToken cancellationToken)
        {
            if (await _destinoRepository.GetByIdAsync(new DestinoId(command.Id)) is not Destino destino)
            {
                return Error.NotFound("Destino.NotFound", "The destination with the provided Id was not found.");
            }

            _destinoRepository.Delete(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
