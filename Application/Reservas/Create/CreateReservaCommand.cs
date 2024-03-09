using Domain.Customers;

public record CreateReservaCommand(
    Domain.Paquetes.PaqueteId IdPaquete,
    CustomerId IdCliente,
    string NombreCliente,
    string EmailCliente,
    string TelefonoCliente,
    DateTime FechaViaje) : IRequest<ErrorOr<Guid>>;
