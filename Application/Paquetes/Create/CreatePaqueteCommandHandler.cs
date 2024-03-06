using Domain.Paquetes;
using Domain.Primitives;

namespace Application.Paquetes.Create
{
    internal sealed class CreatePaqueteCommandHandler : IRequestHandler<CreatePaqueteCommand, ErrorOr<Guid>>
    {
        private readonly IPaqueteRepository _paqueteRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreatePaqueteCommandHandler(IPaqueteRepository paqueteRepository, IUnitOfWork unitOfWork)
        {
            _paqueteRepository = paqueteRepository ?? throw new ArgumentNullException(nameof(paqueteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Guid>> Handle(CreatePaqueteCommand command, CancellationToken cancellationToken)
        {
            var paquete = new Paquete(
                new PaqueteId(Guid.NewGuid()),
                command.Nombre,
                command.Descripcion,
                command.FechaInicio,
                command.FechaFin,
                command.Precio,
                true
            );

            _paqueteRepository.Add(paquete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return paquete.Id.Value;
        }
    }
}
