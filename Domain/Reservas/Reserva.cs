using System;
using Domain.Customers;
using Domain.Paquetes;
using Domain.Primitives;

namespace Domain.Reservas
{
    public sealed class Reserva : AggregateRoot
    {
        public Reserva(ReservaId id, PaqueteId idPaquete, CustomerId clienteId, string nombreCliente, string emailCliente, string telefonoCliente, DateTime fechaViaje)
        {
            Id = id;
            IdPaquete = idPaquete;
            ClienteId = clienteId;
            NombreCliente = nombreCliente;
            EmailCliente = emailCliente;
            TelefonoCliente = telefonoCliente;
            FechaViaje = fechaViaje;
        }

        public ReservaId Id { get; private set; }
        public PaqueteId IdPaquete { get; private set; }
        public CustomerId ClienteId { get; private set; }
        public string NombreCliente { get; private set; } = string.Empty;
        public string EmailCliente { get; private set; } = string.Empty;
        public string TelefonoCliente { get; private set; } = string.Empty;
        public DateTime FechaViaje { get; private set; }

        public void Update(string nombreCliente, string emailCliente, string telefonoCliente, DateTime fechaViaje)
        {
            NombreCliente = nombreCliente;
            EmailCliente = emailCliente;
            TelefonoCliente = telefonoCliente;
            FechaViaje = fechaViaje;
        }

        // Relación con Cliente (una reserva pertenece a un cliente)
        public Customer Cliente { get; set; }

        // Relación con Paquete (una reserva pertenece a un paquete)
        public Paquete Paquete { get; set; }
    }
}
