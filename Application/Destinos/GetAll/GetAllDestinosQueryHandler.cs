using AutoMapper;
using Destinos.Common;
using Domain.Destinos;

namespace Application.Destinos.GetAll
{
    internal sealed class GetAllDestinosQueryHandler : IRequestHandler<GetAllDestinosQuery, List<DestinoResponse>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IMapper _mapper;
        
        public GetAllDestinosQueryHandler(IDestinoRepository destinoRepository, IMapper mapper)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<List<DestinoResponse>> Handle(GetAllDestinosQuery request, CancellationToken cancellationToken)
        {
            var destinos = await _destinoRepository.GetAll();
            return _mapper.Map<List<DestinoResponse>>(destinos);
        }
    }
}
