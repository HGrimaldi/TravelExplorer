using Domain.Primitives;
using Domain.Reservas;
using Domain.ValueObjects;
using System;

namespace Domain.Customers
{
    public  class Customer : AggregateRoot
    {
        // Constructor sin parámetros
        public Customer() {}

        public Customer(CustomerId id, string nombre, string dui, string email, PhoneNumber phoneNumber, Direccion direccion, bool active)
        {
            Id = id;
            Nombre = nombre;
            DUI = dui;
            Email = email;
            PhoneNumber = phoneNumber;
            Direccion = direccion;
            Active = active;
        }

        public ReservaId ReservaId { get; set; }
        public virtual Reserva Reserva {get; set; }

        public CustomerId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string DUI { get; set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public PhoneNumber PhoneNumber { get; private set; }
        public Direccion Direccion { get; private set; }
        public bool Active { get; private set; }

        public void Update(string nombre, string dui, string email, PhoneNumber phoneNumber, Direccion direccion, bool active)
        {
            Nombre = nombre;
            DUI = dui;
            Email = email;
            PhoneNumber = phoneNumber;
            Direccion = direccion;
            Active = active;
        }
    }
}
