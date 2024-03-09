using Domain.Customers;
using Domain.Destinos;
using Domain.Paquetes;
using Domain.Reservas;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Primitives;
using Infrastructure.Persistence.Configuration;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DestinoConfiguration());
            modelBuilder.ApplyConfiguration(new PaqueteConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Paquete)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.IdPaquete);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
