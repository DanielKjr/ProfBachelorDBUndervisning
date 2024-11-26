using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbUndervisning.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DbUndervisningProject");

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "placeholder siden jeg ikke har noget reelt asset")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "DbUndervisningProject",
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
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humanoids",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attackable = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Behavior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attackable = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texture = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Quests",
                schema: "DbUndervisningProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HumanoidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dialogue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemToCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_Humanoids_HumanoidId",
                        column: x => x.HumanoidId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Humanoids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quests_Items_ItemToCreateId",
                        column: x => x.ItemToCreateId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ClassConstraint = table.Column<int>(type: "int", nullable: false),
                    HumanoidId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Humanoids_HumanoidId",
                        column: x => x.HumanoidId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Humanoids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Abilities_Mobs_MobId",
                        column: x => x.MobId,
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Mobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                schema: "DbUndervisningProject",
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
                        principalSchema: "DbUndervisningProject",
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Humanoids_RegionId",
                schema: "DbUndervisningProject",
                table: "Humanoids",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobs_RegionId",
                schema: "DbUndervisningProject",
                table: "Mobs",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_HumanoidId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "HumanoidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_ItemToCreateId",
                schema: "DbUndervisningProject",
                table: "Quests",
                column: "ItemToCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_QuestId",
                schema: "DbUndervisningProject",
                table: "Rewards",
                column: "QuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ItemId",
                schema: "DbUndervisningProject",
                table: "Stats",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Rewards",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Mobs",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Quests",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Humanoids",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "DbUndervisningProject");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "DbUndervisningProject");
        }
    }
}
