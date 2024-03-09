using Domain.Customers;

public record CreateReservaCommand(
    Domain.Paquetes.PaqueteId IdPaquete,
    CustomerId IdCliente, // Usamos CustomerId en lugar de Guid
    string NombreCliente,
    string EmailCliente,
    string TelefonoCliente,
    DateTime FechaViaje) : IRequest<ErrorOr<Guid>>;
