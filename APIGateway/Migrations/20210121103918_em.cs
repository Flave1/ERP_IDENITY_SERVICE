using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class em : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Writing_Rating",
                table: "hrm_emp_language",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Speaking_Rating",
                table: "hrm_emp_language",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Reading_Rating",
                table: "hrm_emp_language",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Approval_status",
                table: "hrm_emp_career",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Approval_status_name",
                table: "hrm_emp_career",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hrm_emp_gym",
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
                    GymId = table.Column<int>(nullable: false),
                    GymRating = table.Column<int>(nullable: false),
                    GymContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_gym", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_gym_change_request",
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
                    GymId = table.Column<int>(nullable: false),
                    EmpGymId = table.Column<int>(nullable: false),
                    ExistingGym = table.Column<string>(nullable: true),
                    SuggestedGym = table.Column<int>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    DateOfRequest = table.Column<DateTime>(nullable: true),
                    ExpectedDateOfChange = table.Column<DateTime>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_gym_change_request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_gym_meeting",
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
                    GymId = table.Column<int>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    ProposedMeetingDate = table.Column<DateTime>(nullable: false),
                    ReasonsForMeeting = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_gym_meeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hmo",
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
                    HmoId = table.Column<int>(nullable: false),
                    Hmo_rating = table.Column<int>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hmo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hmo_change_request",
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
                    HmoId = table.Column<int>(nullable: false),
                    EmpHmoId = table.Column<int>(nullable: false),
                    ExistingHmo = table.Column<string>(nullable: true),
                    SuggestedHmo = table.Column<int>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    DateOfRequest = table.Column<DateTime>(nullable: true),
                    ExpectedDateOfChange = table.Column<DateTime>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hmo_change_request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hospital",
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
                    HospitalId = table.Column<int>(nullable: false),
                    HospitalRating = table.Column<decimal>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hospital_change_request",
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
                    HospitalId = table.Column<int>(nullable: false),
                    EmpHospitalId = table.Column<int>(nullable: false),
                    ExistingHospital = table.Column<string>(nullable: true),
                    SuggestedHospital = table.Column<int>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    DateOfRequest = table.Column<DateTime>(nullable: true),
                    ExpectedDateOfChange = table.Column<DateTime>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hospital_change_request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_emp_hospital_meeting",
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
                    HospitalId = table.Column<int>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    ProposedMeetingDate = table.Column<DateTime>(nullable: false),
                    ReasonsForMeeting = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_emp_hospital_meeting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hrm_emp_gym");

            migrationBuilder.DropTable(
                name: "hrm_emp_gym_change_request");

            migrationBuilder.DropTable(
                name: "hrm_emp_gym_meeting");

            migrationBuilder.DropTable(
                name: "hrm_emp_hmo");

            migrationBuilder.DropTable(
                name: "hrm_emp_hmo_change_request");

            migrationBuilder.DropTable(
                name: "hrm_emp_hospital");

            migrationBuilder.DropTable(
                name: "hrm_emp_hospital_change_request");

            migrationBuilder.DropTable(
                name: "hrm_emp_hospital_meeting");

            migrationBuilder.DropColumn(
                name: "Approval_status",
                table: "hrm_emp_career");

            migrationBuilder.DropColumn(
                name: "Approval_status_name",
                table: "hrm_emp_career");

            migrationBuilder.AlterColumn<string>(
                name: "Writing_Rating",
                table: "hrm_emp_language",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Speaking_Rating",
                table: "hrm_emp_language",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Reading_Rating",
                table: "hrm_emp_language",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
