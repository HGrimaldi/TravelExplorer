using Domain.Customers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
         builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(c => c.Nombre).HasMaxLength(50);

        builder.Property(c => c.DUI).HasMaxLength(50);


        builder.Property(c => c.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(9);

        builder.OwnsOne(c => c.Direccion, direccionBuilder => {

            direccionBuilder.Property(a => a.Country).HasMaxLength(3);

            direccionBuilder.Property(a => a.Line1).HasMaxLength(20);

            direccionBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            direccionBuilder.Property(a => a.City).HasMaxLength(40);

            direccionBuilder.Property(a => a.State).HasMaxLength(40);

            direccionBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });

        builder.Property(c => c.Active);
    }
}