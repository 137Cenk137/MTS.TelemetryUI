using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryUI.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telemetries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Speed = table.Column<double>(type: "REAL", nullable: false),
                    BatteryTemperature = table.Column<double>(type: "REAL", nullable: false),
                    TankTemperature = table.Column<double>(type: "REAL", nullable: false),
                    BatteryVoltage = table.Column<double>(type: "REAL", nullable: false),
                    BatteryRate = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telemetries");
        }
    }
}
