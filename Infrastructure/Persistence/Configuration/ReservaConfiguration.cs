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

            builder.Property(r => r.FechaInicio).IsRequired();

            builder.Property(r => r.FechaFin).IsRequired();

            builder.Property(r => r.Estado).IsRequired();

            // Aquí puedes agregar más configuraciones según sea necesario
        }
    }
}
