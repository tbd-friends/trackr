using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class AddReleaseYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "ReleaseYear",
                table: "SystemTitles",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "SystemTitles");
        }
    }
}
