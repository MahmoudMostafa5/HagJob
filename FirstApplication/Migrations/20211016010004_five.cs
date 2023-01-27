using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepId",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobs_DepartmentId",
                table: "jobs",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_Departments_DepartmentId",
                table: "jobs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Departments_DepartmentId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_DepartmentId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DepId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "jobs");
        }
    }
}
