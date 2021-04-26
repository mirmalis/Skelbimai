using Microsoft.EntityFrameworkCore.Migrations;

namespace Skelbimai.Db.Migrations
{
    public partial class AddedClassificationalternativekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classifications_UserID",
                table: "Classifications");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Classifications_UserID_SkelbimasID",
                table: "Classifications",
                columns: new[] { "UserID", "SkelbimasID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Classifications_UserID_SkelbimasID",
                table: "Classifications");

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_UserID",
                table: "Classifications",
                column: "UserID");
        }
    }
}
