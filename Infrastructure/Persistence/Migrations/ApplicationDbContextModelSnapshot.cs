using System;
using Domain.Customers;
using Domain.Destinos;
using Domain.Paquetes;
using Domain.Reservas;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity<Customer>(b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                // Properties for Customer entity
                b.Property<bool>("Active")
                    .HasColumnType("bit");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("DUI")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<PhoneNumber>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("PhoneNumber");

                b.Property<Direccion>("Direccion")
                    .IsRequired()
                    .HasColumnType("Direccion");

                b.HasKey("Id");

                b.HasIndex("Email")
                    .IsUnique();

                b.ToTable("Customers", (string)null);
            });

            modelBuilder.Entity<Destino>(b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                // Properties for Destino entity
                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Descripcion")
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<string>("Ubicacion")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<bool>("Activo")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("Destinos", (string)null);
            });

            modelBuilder.Entity<Paquete>(b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                // Properties for Paquete entity
                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Descripcion")
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<DateTime>("FechaInicio")
                    .HasColumnType("datetime");

                b.Property<DateTime>("FechaFin")
                    .HasColumnType("datetime");

                b.Property<decimal>("Precio")
                    .HasColumnType("decimal(18,2)");

                b.Property<bool>("Activo")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("Paquetes", (string)null);
            });

            modelBuilder.Entity<Reserva>(b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                // Properties for Reserva entity
                b.Property<Guid>("IdPaquete")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("NombreCliente")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("EmailCliente")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<string>("TelefonoCliente")
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar(20)");

                b.Property<DateTime>("FechaViaje")
                    .HasColumnType("datetime");

                b.HasKey("Id");

                b.ToTable("Reservas", (string)null);
            });

#pragma warning restore 612, 618
        }
    }
}
