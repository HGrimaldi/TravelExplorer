using Domain.Reservas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reservas");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Id)
                .HasConversion(ReservaId => ReservaId.Value,
                               value => new ReservaId(value));

            builder.Property(r => r.NombreCliente).IsRequired();
            builder.Property(r => r.EmailCliente).IsRequired();
            builder.Property(r => r.TelefonoCliente).IsRequired();
            builder.Property(r => r.FechaViaje).IsRequired();

            // Relación con Cliente (una reserva pertenece a un cliente)
            builder.HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            // Relación con Paquete (una reserva pertenece a un paquete)
            builder.HasOne(r => r.Paquete)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.IdPaquete);
        }
    }
}
