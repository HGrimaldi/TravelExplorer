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

            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descripcion).HasMaxLength(255);
        }
    }
}
