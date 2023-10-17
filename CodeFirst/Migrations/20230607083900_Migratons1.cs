using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Migratons1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DrivingLicense = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Car_Person",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    MainOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Person", x => new { x.IdCar, x.IdPerson });
                    table.ForeignKey(
                        name: "FK_Car_Person_Car_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Car",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Person_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "IdCar", "Make", "ProductionYear" },
                values: new object[,]
                {
                    { 1, "BMW", 2004 },
                    { 2, "Fiat", 2014 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IdPerson", "DrivingLicense", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, null, "A", "B" },
                    { 2, "ADSA", "C", "D" }
                });

            migrationBuilder.InsertData(
                table: "Car_Person",
                columns: new[] { "IdCar", "IdPerson", "MainOwner" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 2, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Person_IdPerson",
                table: "Car_Person",
                column: "IdPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_Person");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
