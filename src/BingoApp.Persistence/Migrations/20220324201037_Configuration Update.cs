using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingoApp.Persistence.Migrations
{
    public partial class ConfigurationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Title",
                table: "Tickets",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_Title",
                table: "Tickets");
        }
    }
}
