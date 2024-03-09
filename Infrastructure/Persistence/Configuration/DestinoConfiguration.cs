using Domain.Destinos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.ToTable("Destinos");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                .HasConversion(DestinoId => DestinoId.Value,
                               value => new DestinoId(value));

            builder.Property(d => d.Id)
                .HasColumnName("DestinoId")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Descripcion).HasMaxLength(255);

            // Relación con Paquete (un destino puede estar en muchos paquetes)
            builder.HasMany(d => d.Paquetes)
                .WithMany(p => p.Destinos)
                .UsingEntity(j => j.ToTable("PaqueteDestino"));
        }
    }
}
