using Domain.Paquetes;
using Domain.Primitives;
using System;
using System.Collections.Generic;

namespace Domain.Destinos
{
    public sealed class Destino : AggregateRoot
    {
        public Destino(DestinoId id, string nombre, string descripcion, string ubicacion, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            Activo = activo;
        }

        public DestinoId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Ubicacion { get; private set; } = string.Empty;
        public bool Activo { get; private set; }

        public void Update(string nombre, string descripcion, string ubicacion, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            Activo = activo;
        }

        // Relación con Paquete (un destino puede estar en muchos paquetes)
        public List<Paquete> Paquetes { get; private set; } = new List<Paquete>();
    }
}
