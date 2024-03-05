namespace Application.Destino.Create
{
    internal sealed class CreateDestinoCommandHandler : IRequestHandler<CreateDestinoCommand, ErrorOr<Guid>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateDestinoCommandHandler(IDestinoRepository destinoRepository, IUnitOfWork unitOfWork)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Guid>> Handle(CreateDestinoCommand command, CancellationToken cancellationToken)
        {
            var destino = new Destino(
                new DestinoId(Guid.NewGuid()),
                command.Nombre,
                command.Descripcion,
                command.Ubicacion,
                true
            );

            _destinoRepository.Add(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return destino.Id.Value;
        }
    }
}
