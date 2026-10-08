using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAirlinesWebApp.Migrations
{
    /// <inheritdoc />
    public partial class FlightChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airlines_Cities_CityId",
                table: "Airlines");

            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Cities_CityId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Flights");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFlight",
                table: "Flights",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeFlight",
                table: "Flights",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Airports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Airlines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Airlines_Cities_CityId",
                table: "Airlines",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Cities_CityId",
                table: "Airports",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airlines_Cities_CityId",
                table: "Airlines");

            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Cities_CityId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "DateFlight",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TimeFlight",
                table: "Flights");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Airports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Airlines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Airlines_Cities_CityId",
                table: "Airlines",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Cities_CityId",
                table: "Airports",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
