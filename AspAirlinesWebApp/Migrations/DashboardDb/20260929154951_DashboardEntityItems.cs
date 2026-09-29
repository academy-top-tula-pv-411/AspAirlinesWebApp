using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAirlinesWebApp.Migrations.DashboardDb
{
    /// <inheritdoc />
    public partial class DashboardEntityItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Items");
        }
    }
}
