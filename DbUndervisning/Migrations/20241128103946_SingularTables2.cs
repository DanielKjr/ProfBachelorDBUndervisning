using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class SingularTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_NPC_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_NPC_Quests_QuestId",
                table: "NPC");

            migrationBuilder.DropForeignKey(
                name: "FK_NPC_Regions_RegionId",
                table: "NPC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NPC",
                table: "NPC");

            migrationBuilder.RenameTable(
                name: "NPC",
                newName: "NPCs",
                newSchema: "DbUndervisningProject");

            migrationBuilder.RenameIndex(
                name: "IX_NPC_RegionId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                newName: "IX_NPCs_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_NPC_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                newName: "IX_NPCs_QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NPCs",
                schema: "DbUndervisningProject",
                table: "NPCs",
                column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Abilities_NPCs_NPCId",
            //    schema: "DbUndervisningProject",
            //    table: "Abilities",
            //    column: "NPCId",
            //    principalSchema: "DbUndervisningProject",
            //    principalTable: "NPCs",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NPCs_Quests_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                column: "QuestId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NPCs_Regions_RegionId",
                schema: "DbUndervisningProject",
                table: "NPCs",
                column: "RegionId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Abilities_NPCs_NPCId",
            //    schema: "DbUndervisningProject",
            //    table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_NPCs_Quests_QuestId",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.DropForeignKey(
                name: "FK_NPCs_Regions_RegionId",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NPCs",
                schema: "DbUndervisningProject",
                table: "NPCs");

            migrationBuilder.RenameTable(
                name: "NPCs",
                schema: "DbUndervisningProject",
                newName: "NPC");

            migrationBuilder.RenameIndex(
                name: "IX_NPCs_RegionId",
                table: "NPC",
                newName: "IX_NPC_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_NPCs_QuestId",
                table: "NPC",
                newName: "IX_NPC_QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NPC",
                table: "NPC",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_NPC_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "NPCId",
                principalTable: "NPC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NPC_Quests_QuestId",
                table: "NPC",
                column: "QuestId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NPC_Regions_RegionId",
                table: "NPC",
                column: "RegionId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
