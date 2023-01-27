using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobs_UserId",
                table: "jobs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_AspNetUsers_UserId",
                table: "jobs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_AspNetUsers_UserId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_UserId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "jobs");
        }
    }
}
