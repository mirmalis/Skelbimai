using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skelbimai.Db.Migrations
{
    public partial class classrenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skelbimas_Group");

            migrationBuilder.CreateTable(
                name: "SkelbimasClasification",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkelbimasID = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkelbimasClasification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkelbimasClasification_Skelbimai_SkelbimasID",
                        column: x => x.SkelbimasID,
                        principalTable: "Skelbimai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkelbimasClasification_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkelbimasClasification_SkelbimasID",
                table: "SkelbimasClasification",
                column: "SkelbimasID");

            migrationBuilder.CreateIndex(
                name: "IX_SkelbimasClasification_UserID",
                table: "SkelbimasClasification",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkelbimasClasification");

            migrationBuilder.CreateTable(
                name: "Skelbimas_Group",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false),
                    SkelbimasID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skelbimas_Group", x => x.ID);
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
                name: "IX_Skelbimas_Group_SkelbimasID",
                table: "Skelbimas_Group",
                column: "SkelbimasID");

            migrationBuilder.CreateIndex(
                name: "IX_Skelbimas_Group_UserID",
                table: "Skelbimas_Group",
                column: "UserID");
        }
    }
}
