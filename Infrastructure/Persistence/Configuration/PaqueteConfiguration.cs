using Domain.Paquetes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class PaqueteConfiguration : IEntityTypeConfiguration<Paquete>
    {
        public void Configure(EntityTypeBuilder<Paquete> builder)
        {
            builder.ToTable("Paquetes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Precio)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.Id)
                .HasConversion(PaqueteId => PaqueteId.Value,
                               value => new PaqueteId(value));

            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descripcion).HasMaxLength(255);

            // Relación con Destino (un paquete puede incluir muchos destinos)
            builder.HasMany(p => p.Destinos)
                .WithMany(d => d.Paquetes)
                .UsingEntity(j => j.ToTable("PaqueteDestino"));

            // Relación con Reserva (un paquete puede tener muchas reservas)
            builder.HasMany(p => p.Reservas)
                .WithOne(r => r.Paquete)
                .HasForeignKey(r => r.IdPaquete);
        }
    }
}
