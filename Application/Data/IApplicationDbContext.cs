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
        DbSet<Destino> Destino { get; set; }
        DbSet<Paquete> Paquete { get; set; }
        DbSet<Reserva> Reserva { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
