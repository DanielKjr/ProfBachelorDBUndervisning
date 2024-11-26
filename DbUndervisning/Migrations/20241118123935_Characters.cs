using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class Characters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HashedPw = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Currency = table.Column<double>(type: "float", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quests_CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                schema: "DbUndervisningProject",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                schema: "DbUndervisningProject",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "CharacterId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Items",
                column: "CharacterId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "CharacterId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "DbUndervisningProject");

            migrationBuilder.DropIndex(
                name: "IX_Quests_CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Items_CharacterId",
                schema: "DbUndervisningProject",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");
        }
    }
}
