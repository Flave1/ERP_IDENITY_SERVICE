using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class emma_hrm2we : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hrm_emp_qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    QualificationId = table.Column<int>(nullable: false),
                    QualificationName = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    GradeId = table.Column<int>(nullable: false),
                    Attachment = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_qualification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hrm_emp_qualification");
        }
    }
}
