using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class AddGameCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemTitles",
                table: "SystemTitles");

            migrationBuilder.AlterColumn<short>(
                name: "ReleaseYear",
                table: "SystemTitles",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SystemTitles",
                nullable: false,
                defaultValueSql: "newid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemTitles",
                table: "SystemTitles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameCopies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SystemTitleId = table.Column<Guid>(nullable: false),
                    PricePaid = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    PurchasedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCopies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCopyAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameCopyId = table.Column<Guid>(nullable: false),
                    Attribute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCopyAttributes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemTitles_SystemId",
                table: "SystemTitles",
                column: "SystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCopies");

            migrationBuilder.DropTable(
                name: "GameCopyAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemTitles",
                table: "SystemTitles");

            migrationBuilder.DropIndex(
                name: "IX_SystemTitles_SystemId",
                table: "SystemTitles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SystemTitles");

            migrationBuilder.AlterColumn<short>(
                name: "ReleaseYear",
                table: "SystemTitles",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemTitles",
                table: "SystemTitles",
                columns: new[] { "SystemId", "TitleId" });
        }
    }
}
