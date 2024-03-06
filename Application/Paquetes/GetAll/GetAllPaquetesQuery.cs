using Paquetes.Common;

namespace Application.Paquetes.GetAll
{
    public record GetAllPaquetesQuery() : IRequest<ErrorOr<IReadOnlyList<PaqueteResponse>>>;
}