using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class directory_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Directory_link",
                table: "cor_workflowtask",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Directory_link",
                table: "cor_workflowtask");
        }
    }
}
