using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class emma_hrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "hrm_emp_emergency_contact");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "hrm_emp_dependent_contact");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "hrm_emp_emergency_contact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "hrm_emp_dependent_contact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "hrm_emp_assets",
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
                    AssetName = table.Column<string>(nullable: true),
                    AssetNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    PhysicalCondition = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    RequestApprovalStatus = table.Column<int>(nullable: false),
                    ReturnApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_prof_certification",
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
                    CertificationId = table.Column<int>(nullable: false),
                    Institution = table.Column<string>(nullable: true),
                    DateGranted = table.Column<DateTime>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    GradeId = table.Column<int>(nullable: false),
                    Attachment = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_prof_certification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hrm_emp_assets");

            migrationBuilder.DropTable(
                name: "hrm_emp_prof_certification");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "hrm_emp_emergency_contact");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "hrm_emp_dependent_contact");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "hrm_emp_emergency_contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "hrm_emp_dependent_contact",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
