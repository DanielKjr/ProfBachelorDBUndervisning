using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPlayerDb.Migrations
{
    /// <inheritdoc />
    public partial class NameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Worlds_Name",
                schema: "MultiPlayerDb",
                table: "Worlds",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worlds_Name",
                schema: "MultiPlayerDb",
                table: "Worlds");
        }
    }
}
