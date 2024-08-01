using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    LinkName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Clicks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    IsPremium = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<short>(type: "smallint", nullable: false),
                    Photo = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkTree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Clicks = table.Column<long>(type: "Bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTree_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Clicks = table.Column<long>(type: "bigint", nullable: false),
                    Expires = table.Column<bool>(type: "bit", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    HasPassword = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    HasMessage = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    LinkTreeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_LinkTree_LinkTreeId",
                        column: x => x.LinkTreeId,
                        principalTable: "LinkTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: true),
                    LinkTreeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_LinkTree_LinkTreeId",
                        column: x => x.LinkTreeId,
                        principalTable: "LinkTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Link_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_LinkTreeId",
                table: "Link",
                column: "LinkTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserId",
                table: "Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTree_UserId",
                table: "LinkTree",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LinkId",
                table: "Post",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LinkTreeId",
                table: "Post",
                column: "LinkTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "LinkTree");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
