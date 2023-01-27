using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApplication.Migrations
{
    public partial class hoot8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Statues",
                table: "jobs",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statues",
                table: "jobs");
        }
    }
}
