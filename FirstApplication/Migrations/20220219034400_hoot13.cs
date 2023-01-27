using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class hoot13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_jobs_JobsJob_Id",
                table: "ApplyJobs");

            migrationBuilder.DropIndex(
                name: "IX_ApplyJobs_JobsJob_Id",
                table: "ApplyJobs");

            migrationBuilder.DropColumn(
                name: "JobsJob_Id",
                table: "ApplyJobs");

            migrationBuilder.AlterColumn<int>(
                name: "IdJob",
                table: "ApplyJobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_IdJob",
                table: "ApplyJobs",
                column: "IdJob");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_jobs_IdJob",
                table: "ApplyJobs",
                column: "IdJob",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_jobs_IdJob",
                table: "ApplyJobs");

            migrationBuilder.DropIndex(
                name: "IX_ApplyJobs_IdJob",
                table: "ApplyJobs");

            migrationBuilder.AlterColumn<int>(
                name: "IdJob",
                table: "ApplyJobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobsJob_Id",
                table: "ApplyJobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobsJob_Id",
                table: "ApplyJobs",
                column: "JobsJob_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_jobs_JobsJob_Id",
                table: "ApplyJobs",
                column: "JobsJob_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
