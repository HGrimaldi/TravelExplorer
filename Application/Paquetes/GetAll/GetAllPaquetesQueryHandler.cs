using Domain.Paquetes;
using Paquetes.Common;

namespace Application.Paquetes.GetAll
{
    internal sealed class GetAllPaquetesQueryHandler : IRequestHandler<GetAllPaquetesQuery, ErrorOr<IReadOnlyList<PaqueteResponse>>>
    {
        private readonly IPaqueteRepository _paqueteRepository;
        
        public GetAllPaquetesQueryHandler(IPaqueteRepository paqueteRepository)
        {
            _paqueteRepository = paqueteRepository ?? throw new ArgumentNullException(nameof(paqueteRepository));
        }
        
        public async Task<ErrorOr<IReadOnlyList<PaqueteResponse>>> Handle(GetAllPaquetesQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Paquete> paquetes = await _paqueteRepository.GetAll();

            return paquetes.Select(paquete => new PaqueteResponse(
                    paquete.Id.Value,
                    paquete.Nombre,
                    paquete.Descripcion,
                    paquete.FechaInicio,
                    paquete.FechaFin,
                    paquete.Precio,
                    paquete.Activo
                )).ToList();
        }
    }
}
