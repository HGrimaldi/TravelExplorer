namespace Application.Destino.GetAll
{
    public record GetAllDestinosQuery() : IRequest<ErrorOr<IReadOnlyList<DestinoResponse>>>;
}
