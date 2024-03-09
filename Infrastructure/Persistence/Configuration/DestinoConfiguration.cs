using Domain.Destinos;
using Domain.Paquetes;
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
            .HasConversion(
                DestinoId => DestinoId.Value,
                value => new DestinoId(value)
            );

            builder.Property(c => c.PaqueteId)
            .HasConversion(
                PaqueteId => PaqueteId.Value,
                value => new PaqueteId(value)
            );
  //codigo para hacer la llave foranea
            builder.HasOne(c => c.Paquete)
            .WithMany()
            .HasForeignKey(c => c.PaqueteId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.Id)
                .HasColumnName("DestinoId") // Nombre de la columna en la base de datos
                .ValueGeneratedOnAdd(); // Generar automáticamente valores al agregar nuevos registros

            builder.Property(d => d.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Descripcion).HasMaxLength(255);
        }
    }
}