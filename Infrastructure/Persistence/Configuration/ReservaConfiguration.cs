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
            

            builder.HasOne(c => c.Paquete)
            .WithMany()
            .HasForeignKey(c => c.PaqueteId)
            .OnDelete(DeleteBehavior.Restrict);

            

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Id)
                .HasConversion(ReservaId => ReservaId.Value,
                               value => new ReservaId(value));

            builder.Property(r => r.NombreCliente).IsRequired();
            builder.Property(r => r.EmailCliente).IsRequired();
            builder.Property(r => r.TelefonoCliente).IsRequired();
            builder.Property(r => r.FechaViaje).IsRequired();
        }
    }
}
