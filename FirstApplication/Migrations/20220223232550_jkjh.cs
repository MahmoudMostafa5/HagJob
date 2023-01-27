using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class jkjh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_questions",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_Job_Id",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "QuestionJobId",
                table: "questions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questions",
                table: "questions",
                column: "Job_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_questions",
                table: "questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionJobId",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questions",
                table: "questions",
                column: "QuestionJobId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Job_Id",
                table: "questions",
                column: "Job_Id",
                unique: true);
        }
    }
}
