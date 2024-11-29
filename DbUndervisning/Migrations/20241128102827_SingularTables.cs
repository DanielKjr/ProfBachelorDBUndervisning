using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class SingularTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Humanoids_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "CharacterAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "HumanoidAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "MobAbilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Humanoids",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Mobs",
                schema: "DbUndervisningProject");

            migrationBuilder.DropIndex(
                name: "IX_Quests_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Quests");

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
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPC_Quests_QuestId",
                        column: x => x.QuestId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPC_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NPCId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Abilities_NPC_NPCId",
                        column: x => x.NPCId,
                        principalTable: "NPC",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CharacterId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_NPCId",
                schema: "DbUndervisningProject",
                table: "Abilities",
                column: "NPCId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_QuestId",
                table: "NPC",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_RegionId",
                table: "NPC",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "NPC");

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humanoids",
                schema: "DbUndervisningProject",
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
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humanoids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humanoids_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mobs",
                schema: "DbUndervisningProject",
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
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobs_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HumanoidAbilities",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HumanoidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanoidAbilities", x => x.Id);
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
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobAbilities_Mobs_MobId",
                        column: x => x.MobId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Mobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quests_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "HumanoidId",
                unique: true);

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
                name: "IX_Humanoids_RegionId",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MobAbilities_MobId",
                schema: "DbUndervisningProject",
                table: "MobAbilities",
                column: "MobId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobs_RegionId",
                schema: "DbUndervisningProject",
                table: "Mobs",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Humanoids_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "HumanoidId",
                principalSchema: "DbUndervisningProject",
                principalTable: "Humanoids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
