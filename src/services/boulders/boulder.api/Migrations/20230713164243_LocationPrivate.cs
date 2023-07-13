using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boulder.api.Migrations
{
    /// <inheritdoc />
    public partial class LocationPrivate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Private",
                table: "Locations");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Locations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Locations");

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Locations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
