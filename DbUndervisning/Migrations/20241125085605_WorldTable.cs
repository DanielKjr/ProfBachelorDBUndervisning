using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class WorldTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorldId",
                schema: "DbUndervisningProject",
                table: "Regions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Worlds",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_WorldId",
                schema: "DbUndervisningProject",
                table: "Regions",
                column: "WorldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Worlds_WorldId",
                schema: "DbUndervisningProject",
                table: "Regions",
                column: "WorldId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Worlds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Worlds_WorldId",
                schema: "DbUndervisningProject",
                table: "Regions");

            migrationBuilder.DropTable(
                name: "Worlds",
                schema: "DbUndervisningProject");

            migrationBuilder.DropIndex(
                name: "IX_Regions_WorldId",
                schema: "DbUndervisningProject",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "WorldId",
                schema: "DbUndervisningProject",
                table: "Regions");
        }
    }
}
