using Application.Paquete;

namespace Application.Paquete.GetAll
{
    public record GetAllPaquetesQuery() : IRequest<ErrorOr<IReadOnlyList<PaqueteResponse>>>;
}