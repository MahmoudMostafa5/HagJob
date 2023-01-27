using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Departments_DepartmentId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_DepartmentId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "jobs");

            migrationBuilder.AlterColumn<int>(
                name: "DepId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobs_DepId",
                table: "jobs",
                column: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_Departments_DepId",
                table: "jobs",
                column: "DepId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Departments_DepId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_DepId",
                table: "jobs");

            migrationBuilder.AlterColumn<string>(
                name: "DepId",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
