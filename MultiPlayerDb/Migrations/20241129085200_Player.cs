using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPlayerDb.Migrations
{
	/// <inheritdoc />
	public partial class Player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                schema: "MultiPlayerDb",
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

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                schema: "MultiPlayerDb",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Players_PlayerId",
                schema: "MultiPlayerDb",
                table: "Characters",
                column: "PlayerId",
                principalSchema: "MultiPlayerDb",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Players_PlayerId",
                schema: "MultiPlayerDb",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "MultiPlayerDb");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlayerId",
                schema: "MultiPlayerDb",
                table: "Characters");
        }
    }
}
