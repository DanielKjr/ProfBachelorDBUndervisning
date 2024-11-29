using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPlayerDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MultiPlayerDb");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Currency = table.Column<double>(type: "float", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worlds",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "placeholder siden jeg ikke har noget reelt asset")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Boost = table.Column<double>(type: "float", nullable: false),
                    StatType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                schema: "MultiPlayerDb",
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
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPCs_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NPCId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    ClassConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Abilities_NPCs_NPCId",
                        column: x => x.NPCId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "NPCs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NPCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dialogue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemToCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quests_Items_ItemToCreateId",
                        column: x => x.ItemToCreateId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quests_NPCs_NPCId",
                        column: x => x.NPCId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                schema: "MultiPlayerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<double>(type: "float", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Quests_QuestId",
                        column: x => x.QuestId,
                        principalSchema: "MultiPlayerDb",
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CharacterId",
                schema: "MultiPlayerDb",
                table: "Abilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_NPCId",
                schema: "MultiPlayerDb",
                table: "Abilities",
                column: "NPCId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                schema: "MultiPlayerDb",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_RegionId",
                schema: "MultiPlayerDb",
                table: "NPCs",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_CharacterId",
                schema: "MultiPlayerDb",
                table: "Quests",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_ItemToCreateId",
                schema: "MultiPlayerDb",
                table: "Quests",
                column: "ItemToCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_NPCId",
                schema: "MultiPlayerDb",
                table: "Quests",
                column: "NPCId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_WorldId",
                schema: "MultiPlayerDb",
                table: "Regions",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_QuestId",
                schema: "MultiPlayerDb",
                table: "Rewards",
                column: "QuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ItemId",
                schema: "MultiPlayerDb",
                table: "Stats",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Rewards",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Quests",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "NPCs",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "MultiPlayerDb");

            migrationBuilder.DropTable(
                name: "Worlds",
                schema: "MultiPlayerDb");
        }
    }
}
