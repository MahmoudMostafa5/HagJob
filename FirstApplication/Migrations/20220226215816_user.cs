using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUser",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUser",
                table: "AspNetUsers",
                column: "ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_post_ApplicationUser",
                table: "AspNetUsers",
                column: "ApplicationUser",
                principalTable: "post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_post_ApplicationUser",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUser",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "AspNetUsers");
        }
    }
}
