using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Domain.Destino;

namespace Application.Destino.GetAll
{
    public sealed class GetAllDestinosQueryHandler : IRequestHandler<GetAllDestinosQuery, List<DestinoDto>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IMapper _mapper;
        
        public GetAllDestinosQueryHandler(IDestinoRepository destinoRepository, IMapper mapper)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<List<DestinoDto>> Handle(GetAllDestinosQuery request, CancellationToken cancellationToken)
        {
            var destinos = await _destinoRepository.GetAll();
            return _mapper.Map<List<DestinoDto>>(destinos);
        }
    }
}
