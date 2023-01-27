using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_post_ApplicationUser",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "AspNetUsers",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ApplicationUser",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PostId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_post_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_post_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "post");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "AspNetUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_post_ApplicationUser",
                table: "AspNetUsers",
                column: "ApplicationUser",
                principalTable: "post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
