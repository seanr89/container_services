using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boulder.api.Migrations
{
    /// <inheritdoc />
    public partial class EditedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boulders_Grouping_BoulderGroupId",
                table: "Boulders");

            migrationBuilder.DropForeignKey(
                name: "FK_Grouping_Locations_GymLocationId",
                table: "Grouping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grouping",
                table: "Grouping");

            migrationBuilder.RenameTable(
                name: "Grouping",
                newName: "Groupings");

            migrationBuilder.RenameIndex(
                name: "IX_Grouping_GymLocationId",
                table: "Groupings",
                newName: "IX_Groupings_GymLocationId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeActiveDate",
                table: "Boulders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groupings",
                table: "Groupings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boulders_Groupings_BoulderGroupId",
                table: "Boulders",
                column: "BoulderGroupId",
                principalTable: "Groupings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupings_Locations_GymLocationId",
                table: "Groupings",
                column: "GymLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boulders_Groupings_BoulderGroupId",
                table: "Boulders");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupings_Locations_GymLocationId",
                table: "Groupings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groupings",
                table: "Groupings");

            migrationBuilder.RenameTable(
                name: "Groupings",
                newName: "Grouping");

            migrationBuilder.RenameIndex(
                name: "IX_Groupings_GymLocationId",
                table: "Grouping",
                newName: "IX_Grouping_GymLocationId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeActiveDate",
                table: "Boulders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grouping",
                table: "Grouping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boulders_Grouping_BoulderGroupId",
                table: "Boulders",
                column: "BoulderGroupId",
                principalTable: "Grouping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grouping_Locations_GymLocationId",
                table: "Grouping",
                column: "GymLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
