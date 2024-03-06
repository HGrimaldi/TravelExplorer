namespace Application.Reservas.Create
{
    public record CreateReservaCommand(
        Guid IdPaquete,
        string NombreCliente,
        string EmailCliente,
        string TelefonoCliente,
        DateTime FechaViaje) : IRequest<ErrorOr<Guid>>;
}
