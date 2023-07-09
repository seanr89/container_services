using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace boulder.api.Migrations
{
    /// <inheritdoc />
    public partial class ClimbsAndSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Boulders");

            migrationBuilder.AddColumn<int>(
                name: "BoulderGroupId",
                table: "Boulders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grouping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    GymLocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grouping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grouping_Locations_GymLocationId",
                        column: x => x.GymLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GymLocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Locations_GymLocationId",
                        column: x => x.GymLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Climbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClimbSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Attempts = table.Column<int>(type: "integer", nullable: false),
                    Complete = table.Column<bool>(type: "boolean", nullable: false),
                    Project = table.Column<bool>(type: "boolean", nullable: false),
                    BoulderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Climbs_Boulders_BoulderId",
                        column: x => x.BoulderId,
                        principalTable: "Boulders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Climbs_Sessions_ClimbSessionId",
                        column: x => x.ClimbSessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boulders_BoulderGroupId",
                table: "Boulders",
                column: "BoulderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Climbs_BoulderId",
                table: "Climbs",
                column: "BoulderId");

            migrationBuilder.CreateIndex(
                name: "IX_Climbs_ClimbSessionId",
                table: "Climbs",
                column: "ClimbSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grouping_GymLocationId",
                table: "Grouping",
                column: "GymLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GymLocationId",
                table: "Sessions",
                column: "GymLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boulders_Grouping_BoulderGroupId",
                table: "Boulders",
                column: "BoulderGroupId",
                principalTable: "Grouping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boulders_Grouping_BoulderGroupId",
                table: "Boulders");

            migrationBuilder.DropTable(
                name: "Climbs");

            migrationBuilder.DropTable(
                name: "Grouping");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Boulders_BoulderGroupId",
                table: "Boulders");

            migrationBuilder.DropColumn(
                name: "BoulderGroupId",
                table: "Boulders");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Boulders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
