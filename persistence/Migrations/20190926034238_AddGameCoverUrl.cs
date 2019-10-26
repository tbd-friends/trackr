using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class AddGameCoverUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverArtUrl",
                table: "SystemTitles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCopyAttributes_GameCopyId",
                table: "GameCopyAttributes",
                column: "GameCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCopyAttributes_GameCopies_GameCopyId",
                table: "GameCopyAttributes",
                column: "GameCopyId",
                principalTable: "GameCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCopyAttributes_GameCopies_GameCopyId",
                table: "GameCopyAttributes");

            migrationBuilder.DropIndex(
                name: "IX_GameCopyAttributes_GameCopyId",
                table: "GameCopyAttributes");

            migrationBuilder.DropColumn(
                name: "CoverArtUrl",
                table: "SystemTitles");
        }
    }
}
