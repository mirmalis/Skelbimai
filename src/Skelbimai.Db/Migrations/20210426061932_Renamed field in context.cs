using Microsoft.EntityFrameworkCore.Migrations;

namespace Skelbimai.Db.Migrations
{
    public partial class Renamedfieldincontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skelbimas_Group_Reasons_GroupID",
                table: "Skelbimas_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons");

            migrationBuilder.RenameTable(
                name: "Reasons",
                newName: "Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skelbimas_Group_Groups_GroupID",
                table: "Skelbimas_Group",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skelbimas_Group_Groups_GroupID",
                table: "Skelbimas_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Reasons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skelbimas_Group_Reasons_GroupID",
                table: "Skelbimas_Group",
                column: "GroupID",
                principalTable: "Reasons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
