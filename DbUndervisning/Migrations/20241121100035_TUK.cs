using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class TUK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humanoids_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobs_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropTable(
                name: "NPC");

            migrationBuilder.AddColumn<bool>(
                name: "Attackable",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Behavior",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Health",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Texture",
                schema: "DbUndervisningProject",
                table: "Mobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Attackable",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Behavior",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Health",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Texture",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attackable",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Behavior",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Health",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Texture",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropColumn(
                name: "Attackable",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Behavior",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Health",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropColumn(
                name: "Texture",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.CreateTable(
                name: "NPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attackable = table.Column<bool>(type: "bit", nullable: false),
                    Behavior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Humanoids_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                column: "Id",
                principalTable: "NPC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobs_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Mobs",
                column: "Id",
                principalTable: "NPC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
