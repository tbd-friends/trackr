using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class RenameAllTheTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCopyAttributes");

            migrationBuilder.DropTable(
                name: "SystemTitles");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "GameTitles");

            migrationBuilder.DropColumn(
                name: "SystemTitleId",
                table: "GameCopies");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameCopies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    ReleaseYear = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Value = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCopyTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameCopyId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCopyTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCopyTags_GameCopies_GameCopyId",
                        column: x => x.GameCopyId,
                        principalTable: "GameCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCopyTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    GameConsoleId = table.Column<Guid>(nullable: false),
                    TitleId = table.Column<Guid>(nullable: false),
                    ReleaseYear = table.Column<short>(nullable: true),
                    CoverArtUrl = table.Column<string>(nullable: true),
                    IsWanted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameConsoles_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCopyTags_GameCopyId",
                table: "GameCopyTags",
                column: "GameCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCopyTags_TagId",
                table: "GameCopyTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameConsoleId",
                table: "Games",
                column: "GameConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TitleId",
                table: "Games",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCopyTags");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameCopies");

            migrationBuilder.AddColumn<Guid>(
                name: "SystemTitleId",
                table: "GameCopies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GameCopyAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameCopyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCopyAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCopyAttributes_GameCopies_GameCopyId",
                        column: x => x.GameCopyId,
                        principalTable: "GameCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    CoverArtUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseYear = table.Column<short>(type: "smallint", nullable: true),
                    SystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemTitles_Systems_SystemId",
                        column: x => x.SystemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemTitles_GameTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "GameTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCopyAttributes_GameCopyId",
                table: "GameCopyAttributes",
                column: "GameCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTitles_SystemId",
                table: "SystemTitles",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTitles_TitleId",
                table: "SystemTitles",
                column: "TitleId");
        }
    }
}
