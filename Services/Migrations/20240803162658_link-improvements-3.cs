using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class linkimprovements3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Link",
                type: "NVARCHAR(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Link",
                type: "NVARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "LinkTreeId",
                table: "Link",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Link",
                type: "NVARCHAR(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Link",
                type: "NVARCHAR(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LinkTreeId",
                table: "Link",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
