using Destinos.Common;
using Domain.Destinos;

namespace Application.Destinos.GetById
{
    internal sealed class GetDestinoByIdQueryHandler : IRequestHandler<GetDestinoByIdQuery, ErrorOr<DestinoResponse>>
    {
        private readonly IDestinoRepository _destinoRepository;
        
        public GetDestinoByIdQueryHandler(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
        }
        
        public async Task<ErrorOr<DestinoResponse>> Handle(GetDestinoByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _destinoRepository.GetByIdAsync(new DestinoId(query.Id)) is not Destino destino)
            {
                return Error.NotFound("Destino.NotFound", "The destination with the provided Id was not found.");
            }

            return new DestinoResponse(
                destino.Id.Value, 
                destino.Nombre, 
                destino.Descripcion, 
                destino.Ubicacion, 
                destino.Activo);
        }
    }
}
