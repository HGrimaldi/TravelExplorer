using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Domain.Reservas;
using Reservas.Common;

namespace Application.Reservas.GetAll
{
    internal sealed class GetAllReservasQueryHandler : IRequestHandler<GetAllReservasQuery, List<ReservaResponse>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public GetAllReservasQueryHandler(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ReservaResponse>> Handle(GetAllReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = await _reservaRepository.GetAll();
            return _mapper.Map<List<ReservaResponse>>(reservas);
        }
    }
}
