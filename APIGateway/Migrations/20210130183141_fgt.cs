using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class fgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPhoneNo",
                table: "hrm_emp_hospital_change_request");

            migrationBuilder.DropColumn(
                name: "EmpHospitalId",
                table: "hrm_emp_hospital_change_request");

            migrationBuilder.DropColumn(
                name: "End_Date",
                table: "hrm_emp_hospital_change_request");

            migrationBuilder.DropColumn(
                name: "ExistingHospital",
                table: "hrm_emp_hospital_change_request");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "hrm_emp_hospital_change_request");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNo",
                table: "hrm_emp_hmo_change_request");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNo",
                table: "hrm_emp_gym_change_request");

            migrationBuilder.DropColumn(
                name: "EmpGymId",
                table: "hrm_emp_gym_change_request");

            migrationBuilder.DropColumn(
                name: "End_Date",
                table: "hrm_emp_gym_change_request");

            migrationBuilder.DropColumn(
                name: "ExistingGym",
                table: "hrm_emp_gym_change_request");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "hrm_emp_gym_change_request");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfJoin",
                table: "hrm_staffs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobGrade",
                table: "hrm_staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReportingTo",
                table: "hrm_staffs",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "hrm_setup_hmo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ratings",
                table: "hrm_setup_gym_workouts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hmo_rating",
                table: "hrm_emp_hmo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "GymRating",
                table: "hrm_emp_gym",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfJoin",
                table: "hrm_staffs");

            migrationBuilder.DropColumn(
                name: "JobGrade",
                table: "hrm_staffs");

            migrationBuilder.DropColumn(
                name: "ReportingTo",
                table: "hrm_staffs");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "hrm_setup_hmo",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Ratings",
                table: "hrm_setup_gym_workouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNo",
                table: "hrm_emp_hospital_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpHospitalId",
                table: "hrm_emp_hospital_change_request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "End_Date",
                table: "hrm_emp_hospital_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExistingHospital",
                table: "hrm_emp_hospital_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "hrm_emp_hospital_change_request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNo",
                table: "hrm_emp_hmo_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Hmo_rating",
                table: "hrm_emp_hmo",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNo",
                table: "hrm_emp_gym_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpGymId",
                table: "hrm_emp_gym_change_request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "End_Date",
                table: "hrm_emp_gym_change_request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExistingGym",
                table: "hrm_emp_gym_change_request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "hrm_emp_gym_change_request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GymRating",
                table: "hrm_emp_gym",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
