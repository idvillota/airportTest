using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportTest.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(maxLength: 150, nullable: true),
                    CityIata = table.Column<string>(maxLength: 5, nullable: false),
                    Iata = table.Column<string>(maxLength: 5, nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: true),
                    TimeZoneRegionName = table.Column<string>(maxLength: 60, nullable: true),
                    CountryIata = table.Column<string>(maxLength: 5, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Hubs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(nullable: false),
                    Lon = table.Column<string>(maxLength: 15, nullable: false),
                    Lat = table.Column<string>(maxLength: 15, nullable: false),
                    AirportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AirportId",
                table: "Locations",
                column: "AirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
