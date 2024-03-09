using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Direccion_Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Direccion_Line1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Line2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Direccion_City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion_State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion_ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    DestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.DestinoId);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteDestino",
                columns: table => new
                {
                    DestinosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaquetesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteDestino", x => new { x.DestinosId, x.PaquetesId });
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Destinos_DestinosId",
                        column: x => x.DestinosId,
                        principalTable: "Destinos",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Paquetes_PaquetesId",
                        column: x => x.PaquetesId,
                        principalTable: "Paquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaViaje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Customers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Paquetes_IdPaquete",
                        column: x => x.IdPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteDestino_PaquetesId",
                table: "PaqueteDestino",
                column: "PaquetesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdPaquete",
                table: "Reservas",
                column: "IdPaquete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaqueteDestino");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Paquetes");
        }
    }
}
