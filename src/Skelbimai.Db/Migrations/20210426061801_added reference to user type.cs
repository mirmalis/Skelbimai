using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skelbimai.Db.Migrations
{
    public partial class addedreferencetousertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ID2 = table.Column<Guid>(type: "TEXT", nullable: false),
                    ID3 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skelbimas_Group",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkelbimasID = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skelbimas_Group", x => new { x.UserID, x.SkelbimasID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_Skelbimas_Group_Reasons_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Reasons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skelbimas_Group_Skelbimai_SkelbimasID",
                        column: x => x.SkelbimasID,
                        principalTable: "Skelbimai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skelbimas_Group_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skelbimas_Group_GroupID",
                table: "Skelbimas_Group",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Skelbimas_Group_SkelbimasID",
                table: "Skelbimas_Group",
                column: "SkelbimasID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skelbimas_Group");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
