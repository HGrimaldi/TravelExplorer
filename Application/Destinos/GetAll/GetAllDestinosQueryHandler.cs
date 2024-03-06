using AutoMapper;
using Domain.Destinos;
using Destinos.Common;

namespace Application.Destinos.GetAll
{
    internal sealed class GetAllDestinosQueryHandler : IRequestHandler<GetAllDestinosQuery, ErrorOr<IReadOnlyList<DestinoResponse>>>
    {
        private readonly IDestinoRepository _destinoRepository;

        public GetAllDestinosQueryHandler(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<DestinoResponse>>> Handle(GetAllDestinosQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Destino> destinos = await _destinoRepository.GetAll();

            return destinos.Select(destino => new DestinoResponse(
                    destino.Id.Value,
                    destino.Nombre,
                    destino.Descripcion,
                    destino.Ubicacion,
                    destino.Activo
                )).ToList();
        }
    }
}
