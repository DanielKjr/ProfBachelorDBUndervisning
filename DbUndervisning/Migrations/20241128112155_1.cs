using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Abilities_NPCs_NPCId",
            //    schema: "DbUndervisningProject",
            //    table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_NPCs_Quests_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.DropIndex(
                name: "IX_NPCs_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.DropColumn(
                name: "QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.AddColumn<Guid>(
                name: "NPCId",
                schema: "DbUndervisningProject",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_NPCId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "NPCId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_NPCs_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "NPCId",
                principalSchema: "DbUndervisningProject",
                principalTable: "NPCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_NPCs_NPCId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "NPCId",
                principalSchema: "DbUndervisningProject",
                principalTable: "NPCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_NPCs_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_NPCs_NPCId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_NPCId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "NPCId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_NPCs_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "NPCId",
                principalSchema: "DbUndervisningProject",
                principalTable: "NPCs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NPCs_Quests_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                column: "QuestId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
