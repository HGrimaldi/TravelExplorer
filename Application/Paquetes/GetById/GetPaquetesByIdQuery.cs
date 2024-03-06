using Paquetes.Common;

namespace Application.Paquetes.GetById
{
    public record GetPaquetesByIdQuery(Guid Id) : IRequest<ErrorOr<PaqueteResponse>>;
}
