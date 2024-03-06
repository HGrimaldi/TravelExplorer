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

<<<<<<< HEAD
            builder.Property(d => d.Id)
                .HasColumnName("DestinoId") // Nombre de la columna en la base de datos
                .ValueGeneratedOnAdd(); // Generar automáticamente valores al agregar nuevos registros

            builder.Property(d => d.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Descripcion).HasMaxLength(255);
=======
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Nombre).HasMaxLength(100).IsRequired();

            builder.Property(d => d.Descripcion).HasMaxLength(500).IsRequired();

>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b
        }
    }
}
