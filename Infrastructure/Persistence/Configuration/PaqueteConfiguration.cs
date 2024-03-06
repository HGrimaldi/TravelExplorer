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
<<<<<<< HEAD
            builder.Property(p => p.Descripcion).HasMaxLength(255);
=======

            builder.Property(p => p.Descripcion).HasMaxLength(500).IsRequired();
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b
        }
    }
}
