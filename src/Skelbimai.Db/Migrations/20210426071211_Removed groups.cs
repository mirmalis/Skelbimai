using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skelbimai.Db.Migrations
{
    public partial class Removedgroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skelbimas_Group_Groups_GroupID",
                table: "Skelbimas_Group");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skelbimas_Group",
                table: "Skelbimas_Group");

            migrationBuilder.DropIndex(
                name: "IX_Skelbimas_Group_GroupID",
                table: "Skelbimas_Group");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Skelbimas_Group",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "Skelbimas_Group",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skelbimas_Group",
                table: "Skelbimas_Group",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Skelbimas_Group_UserID",
                table: "Skelbimas_Group",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skelbimas_Group",
                table: "Skelbimas_Group");

            migrationBuilder.DropIndex(
                name: "IX_Skelbimas_Group_UserID",
                table: "Skelbimas_Group");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Skelbimas_Group");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Skelbimas_Group",
                newName: "GroupID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skelbimas_Group",
                table: "Skelbimas_Group",
                columns: new[] { "UserID", "SkelbimasID", "GroupID" });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false),
                    Desc = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skelbimas_Group_GroupID",
                table: "Skelbimas_Group",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skelbimas_Group_Groups_GroupID",
                table: "Skelbimas_Group",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
