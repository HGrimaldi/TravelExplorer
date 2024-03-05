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

            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Nombre).HasMaxLength(100).IsRequired();

            builder.Property(d => d.Descripcion).HasMaxLength(500).IsRequired();

        }
    }
}
