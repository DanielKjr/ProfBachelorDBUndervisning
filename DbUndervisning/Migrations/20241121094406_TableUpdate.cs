using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_HumanoidAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_MobAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abilities",
                schema: "DbUndervisningProject",
                table: "Abilities");

            migrationBuilder.RenameTable(
                name: "Abilities",
                schema: "DbUndervisningProject",
                newName: "Ability");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ability",
                table: "Ability",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                column: "Id",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HumanoidAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                column: "Id",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                column: "Id",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_HumanoidAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_MobAbilities_Ability_Id",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ability",
                table: "Ability");

            migrationBuilder.RenameTable(
                name: "Ability",
                newName: "Abilities",
                newSchema: "DbUndervisningProject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abilities",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                column: "Id",
                principalSchema: "DbUndervisningProject",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HumanoidAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                column: "Id",
                principalSchema: "DbUndervisningProject",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobAbilities_Abilities_Id",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                column: "Id",
                principalSchema: "DbUndervisningProject",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
