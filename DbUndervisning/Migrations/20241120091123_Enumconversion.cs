using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class Enumconversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Items_ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "NPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attackable = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Behavior = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Items_ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "ItemToCreateId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humanoids_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Humanoids");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobs_NPC_Id",
                schema: "DbUndervisningProject",
                table: "Mobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Items_ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "NPC");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "Class",
                schema: "DbUndervisningProject",
                table: "Characters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Items_ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "ItemToCreateId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
