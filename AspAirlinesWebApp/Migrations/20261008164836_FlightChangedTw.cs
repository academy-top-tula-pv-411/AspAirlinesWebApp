using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAirlinesWebApp.Migrations
{
    /// <inheritdoc />
    public partial class FlightChangedTw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "TimeFlight",
                table: "Flights",
                type: "time",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateFlight",
                table: "Flights",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "TimeFlight",
                table: "Flights",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateFlight",
                table: "Flights",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
