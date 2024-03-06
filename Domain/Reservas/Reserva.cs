using Domain.Primitives;
using System;

namespace Domain.Reservas
{
    public sealed class Reserva : AggregateRoot
    {
        // Constructor sin parámetros
        public Reserva() {}

        public Reserva(ReservaId id, Guid idPaquete, string nombreCliente, string emailCliente, string telefonoCliente, DateTime fechaViaje)
        {
            Id = id;
            IdPaquete = idPaquete;
            NombreCliente = nombreCliente;
            EmailCliente = emailCliente;
            TelefonoCliente = telefonoCliente;
            FechaViaje = fechaViaje;
        }

        public ReservaId Id { get; private set; }
        public Guid IdPaquete { get; private set; }
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
    }
}
