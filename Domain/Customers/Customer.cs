using Domain.Primitives;
using Domain.ValueObjects;
using System;

namespace Domain.Customers
{
    public sealed class Customer : AggregateRoot
    {
<<<<<<< HEAD
        // Constructor sin parámetros
        public Customer() {}

=======
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b
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
