using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cruddemo.Migrations
{
    /// <inheritdoc />
    public partial class agregandoSubmenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "MenusLaterales",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "MenusLaterales",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MenusLaterales",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenusLaterales_ParentId",
                table: "MenusLaterales",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenusLaterales_MenusLaterales_ParentId",
                table: "MenusLaterales",
                column: "ParentId",
                principalTable: "MenusLaterales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenusLaterales_MenusLaterales_ParentId",
                table: "MenusLaterales");

            migrationBuilder.DropIndex(
                name: "IX_MenusLaterales_ParentId",
                table: "MenusLaterales");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenusLaterales");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "MenusLaterales",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "MenusLaterales",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
