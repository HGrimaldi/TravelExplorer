namespace Application.Paquete.Delete
{
    internal sealed class DeletePaqueteCommandHandler : IRequestHandler<DeletePaqueteCommand, ErrorOr<Unit>>
    {
        private readonly IPaqueteRepository _paqueteRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public DeletePaqueteCommandHandler(IPaqueteRepository paqueteRepository, IUnitOfWork unitOfWork)
        {
            _paqueteRepository = paqueteRepository ?? throw new ArgumentNullException(nameof(paqueteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Unit>> Handle(DeletePaqueteCommand command, CancellationToken cancellationToken)
        {
            if (await _paqueteRepository.GetByIdAsync(new PaqueteId(command.Id)) is not Paquete paquete)
            {
                return Error.NotFound("Paquete.NotFound", "The package with the provided Id was not found.");
            }

            _paqueteRepository.Delete(paquete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
