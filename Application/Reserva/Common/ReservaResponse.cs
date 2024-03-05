namespace Customers.Common
{
    public record ReservaResponse(
        Guid Id,
        Guid IdPaquete,
        string NombreCliente,
        string EmailCliente,
        string TelefonoCliente,
        DateTime FechaViaje
    );
}
