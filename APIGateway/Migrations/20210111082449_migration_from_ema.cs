using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class migration_from_ema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hrm_setup_sub_skill_hrm_setup_jobdetails_hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.DropIndex(
                name: "IX_hrm_setup_sub_skill_hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.DropColumn(
                name: "hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.AddColumn<int>(
                name: "hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hrm_emp_career",
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
                    Job_GradeId = table.Column<int>(nullable: false),
                    Job_titleId = table.Column<int>(nullable: false),
                    Job_type = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Office = table.Column<string>(nullable: true),
                    Line_Manager = table.Column<string>(nullable: true),
                    Start_date = table.Column<DateTime>(nullable: true),
                    First_Level_Reviewer = table.Column<string>(nullable: true),
                    Second_Level_Reviewer = table.Column<string>(nullable: true),
                    Start_month = table.Column<string>(nullable: true),
                    Start_year = table.Column<string>(nullable: true),
                    End_month = table.Column<string>(nullable: true),
                    End_year = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_career", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_dependent_contact",
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
                    FullName = table.Column<string>(nullable: true),
                    Contact_phone_number = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Approval_status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_dependent_contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_emergency_contact",
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
                    FullName = table.Column<string>(nullable: true),
                    Contact_phone_number = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Approval_status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_emergency_contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hobbies",
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
                    HobbyName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_identifications",
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
                    Identification = table.Column<string>(nullable: true),
                    Identification_number = table.Column<int>(nullable: false),
                    IdIssues = table.Column<string>(nullable: true),
                    IdExpiry_date = table.Column<DateTime>(nullable: true),
                    IdentificationFilePath = table.Column<string>(nullable: true),
                    Approval_status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_identifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_language",
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
                    LanguageId = table.Column<int>(nullable: false),
                    Reading_Rating = table.Column<string>(nullable: true),
                    Writing_Rating = table.Column<string>(nullable: true),
                    Speaking_Rating = table.Column<string>(nullable: true),
                    Approval_status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_referees",
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
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    NumberOfYears = table.Column<int>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ConfirmationReceived = table.Column<bool>(nullable: false),
                    ConfirmationDate = table.Column<DateTime>(nullable: true),
                    RefereeFilePath = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_referees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hrm_setup_sub_skill_hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill",
                column: "hrm_setup_jobtitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_hrm_setup_sub_skill_hrm_setup_jobdetails_hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill",
                column: "hrm_setup_jobtitleId",
                principalTable: "hrm_setup_jobtitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hrm_setup_sub_skill_hrm_setup_jobdetails_hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.DropTable(
                name: "hrm_emp_career");

            migrationBuilder.DropTable(
                name: "hrm_emp_dependent_contact");

            migrationBuilder.DropTable(
                name: "hrm_emp_emergency_contact");

            migrationBuilder.DropTable(
                name: "hrm_emp_hobbies");

            migrationBuilder.DropTable(
                name: "hrm_emp_identifications");

            migrationBuilder.DropTable(
                name: "hrm_emp_language");

            migrationBuilder.DropTable(
                name: "hrm_emp_referees");

            migrationBuilder.DropIndex(
                name: "IX_hrm_setup_sub_skill_hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.DropColumn(
                name: "hrm_setup_jobtitleId",
                table: "hrm_setup_sub_skill");

            migrationBuilder.AddColumn<int>(
                name: "hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hrm_setup_sub_skill_hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill",
                column: "hrm_setup_jobdetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_hrm_setup_sub_skill_hrm_setup_jobdetails_hrm_setup_jobdetailsId",
                table: "hrm_setup_sub_skill",
                column: "hrm_setup_jobdetailsId",
                principalTable: "hrm_setup_jobtitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
