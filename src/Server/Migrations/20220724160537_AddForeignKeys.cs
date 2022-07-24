using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "RootFolderPath",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "RootFolderId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RootFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootFolders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FileId",
                table: "Movies",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_FileId",
                table: "Episodes",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Files_FileId",
                table: "Episodes",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Files_FileId",
                table: "Movies",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SeriesId",
                table: "Seasons",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Files_FileId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Files_FileId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SeriesId",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "RootFolders");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FileId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_FileId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "RootFolderId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootFolderPath",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
