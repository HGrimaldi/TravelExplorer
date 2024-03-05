namespace Application.Paquete.GetById
{
    public record GetPaquetesByIdQuery(Guid Id) : IRequest<ErrorOr<PaqueteResponse>>;
}
