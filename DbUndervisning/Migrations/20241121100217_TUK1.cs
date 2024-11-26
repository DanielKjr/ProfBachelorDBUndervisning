using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class TUK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.AddColumn<string>(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropColumn(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "MobAbilities");

            migrationBuilder.DropColumn(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropColumn(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "HumanoidAbilities");

            migrationBuilder.DropColumn(
                name: "ClassConstraint",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.DropColumn(
                name: "Damage",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "DbUndervisningProject",
                table: "CharacterAbilities");

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                });

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
    }
}
