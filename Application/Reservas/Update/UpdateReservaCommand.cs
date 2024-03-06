namespace Application.Reservas.Update
{
    public record UpdateReservaCommand(
        Guid Id,
        string NombreCliente,
        string EmailCliente,
        string TelefonoCliente,
        DateTime FechaViaje) : IRequest<ErrorOr<Unit>>;
}

