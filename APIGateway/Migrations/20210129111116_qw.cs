using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class qw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "hrm_emp_qualification");

            migrationBuilder.DropColumn(
                name: "QualificationName",
                table: "hrm_emp_qualification");

            migrationBuilder.DropColumn(
                name: "EmpHmoId",
                table: "hrm_emp_hmo_change_request");

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "hrm_emp_qualification",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpiryDate",
                table: "hrm_emp_prof_certification",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Date",
                table: "hrm_emp_hospital_change_request",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "hrm_emp_hospital",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "SuggestedHmoName",
                table: "hrm_emp_hmo_change_request",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Date",
                table: "hrm_emp_hmo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hrm_staffsStaffId",
                table: "cor_workflowlevelstaff",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hrm_emp_skills",
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
                    SkillId = table.Column<int>(nullable: false),
                    ExpectedScore = table.Column<int>(nullable: false),
                    ActualScore = table.Column<int>(nullable: false),
                    ProofOfSkills = table.Column<string>(nullable: true),
                    ProofOfSkillsUrl = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    StaffCode = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    JobTitle = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    StaffLimit = table.Column<decimal>(nullable: true),
                    AccessLevel = table.Column<int>(nullable: true),
                    StaffOfficeId = table.Column<int>(nullable: true),
                    cor_stateStateId = table.Column<int>(nullable: true),
                    cor_countryCountryId = table.Column<int>(nullable: true),
                    IsHRAdmin = table.Column<bool>(nullable: false),
                    PPEAdmin = table.Column<bool>(nullable: false),
                    IsPandPAdmin = table.Column<bool>(nullable: false),
                    IsCreditAdmin = table.Column<bool>(nullable: false),
                    IsInvestorFundAdmin = table.Column<bool>(nullable: false),
                    IsDepositAdmin = table.Column<bool>(nullable: false),
                    IsTreasuryAdmin = table.Column<bool>(nullable: false),
                    IsExpenseManagementAdmin = table.Column<bool>(nullable: false),
                    IsFinanceAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_hrm_staffs_cor_country_cor_countryCountryId",
                        column: x => x.cor_countryCountryId,
                        principalTable: "cor_country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hrm_staffs_cor_state_cor_stateStateId",
                        column: x => x.cor_stateStateId,
                        principalTable: "cor_state",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cor_workflowlevelstaff_hrm_staffsStaffId",
                table: "cor_workflowlevelstaff",
                column: "hrm_staffsStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_hrm_staffs_cor_countryCountryId",
                table: "hrm_staffs",
                column: "cor_countryCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_hrm_staffs_cor_stateStateId",
                table: "hrm_staffs",
                column: "cor_stateStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_cor_workflowlevelstaff_hrm_staffs_hrm_staffsStaffId",
                table: "cor_workflowlevelstaff",
                column: "hrm_staffsStaffId",
                principalTable: "hrm_staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cor_workflowlevelstaff_hrm_staffs_hrm_staffsStaffId",
                table: "cor_workflowlevelstaff");

            migrationBuilder.DropTable(
                name: "hrm_emp_skills");

            migrationBuilder.DropTable(
                name: "hrm_staffs");

            migrationBuilder.DropIndex(
                name: "IX_cor_workflowlevelstaff_hrm_staffsStaffId",
                table: "cor_workflowlevelstaff");

            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "hrm_emp_qualification");

            migrationBuilder.DropColumn(
                name: "SuggestedHmoName",
                table: "hrm_emp_hmo_change_request");

            migrationBuilder.DropColumn(
                name: "hrm_staffsStaffId",
                table: "cor_workflowlevelstaff");

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "hrm_emp_qualification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QualificationName",
                table: "hrm_emp_qualification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "hrm_emp_prof_certification",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "hrm_emp_hospital_change_request",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "hrm_emp_hospital",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpHmoId",
                table: "hrm_emp_hmo_change_request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Date",
                table: "hrm_emp_hmo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
