// UpdateReservaCommand.cs
using Domain.Customers;
using Domain.Paquetes;

namespace Application.Reservas.Update
{
    public record UpdateReservaCommand(
        Guid Id,
        CustomerId IdCliente,
        PaqueteId IdPaquete,
        string NombreCliente,
        string EmailCliente,
        string TelefonoCliente,
        DateTime FechaViaje) : IRequest<ErrorOr<Unit>>;
}