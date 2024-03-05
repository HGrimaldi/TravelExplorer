namespace Application.Destino.GetById
{
    public record GetDestinoByIdQuery(Guid Id) : IRequest<ErrorOr<DestinoResponse>>;
}
