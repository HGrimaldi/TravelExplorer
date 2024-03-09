using Domain.Destinos;
using Domain.Primitives;
using Domain.Reservas;
using System;
using System.Collections.Generic;

namespace Domain.Paquetes
{
    public sealed class Paquete : AggregateRoot
    {
        public Paquete(PaqueteId id, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, decimal precio, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Precio = precio;
            Activo = activo;
        }

        public PaqueteId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public decimal Precio { get; private set; }
        public bool Activo { get; private set; }

        public void Update(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, decimal precio, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Precio = precio;
            Activo = activo;
        }

        // Relación con Destino (un paquete puede incluir muchos destinos)
        public List<Destino> Destinos { get; private set; } = new List<Destino>();

        // Relación con Reserva (un paquete puede tener muchas reservas)
        public List<Reserva> Reservas { get; private set; } = new List<Reserva>();
    }
}
