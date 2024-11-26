using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class UniqueAbilityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Humanoids_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Mobs_MobId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_MobId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "MobId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Abilities_Id",
                        column: x => x.Id,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HumanoidAbilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HumanoidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanoidAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumanoidAbilities_Abilities_Id",
                        column: x => x.Id,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HumanoidAbilities_Humanoids_HumanoidId",
                        column: x => x.HumanoidId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Humanoids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobAbilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobAbilities_Abilities_Id",
                        column: x => x.Id,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobAbilities_Mobs_MobId",
                        column: x => x.MobId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Mobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_HumanoidAbilities_HumanoidId",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                column: "HumanoidId");

            migrationBuilder.CreateIndex(
                name: "IX_MobAbilities_MobId",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                column: "MobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "HumanoidAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "MobAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MobId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "HumanoidId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_MobId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "MobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "CharacterId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Humanoids_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "HumanoidId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Humanoids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Mobs_MobId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "MobId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Mobs",
                principalColumn: "Id");
        }
    }
}
