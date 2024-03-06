using Destinos.Common;

namespace Application.Destinos.GetAll
{
    public record GetAllDestinosQuery() : IRequest<List<DestinoResponse>>;
}
