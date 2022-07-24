using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddForeignKeyRootFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Files_RootFolderId",
                table: "Files",
                column: "RootFolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_RootFolders_RootFolderId",
                table: "Files",
                column: "RootFolderId",
                principalTable: "RootFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_RootFolders_RootFolderId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_RootFolderId",
                table: "Files");
        }
    }
}
