using Domain.Customers;
using Domain.Destino;
using Domain.Paquete;
using Domain.Reserva;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Destino> Destinos { get; set; }
        DbSet<Paquete> Paquetes { get; set; }
        DbSet<Reserva> Reservas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
