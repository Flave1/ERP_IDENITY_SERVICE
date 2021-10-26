using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class fh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_Date",
                table: "hrm_emp_hmo_change_request");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "hrm_emp_hmo_change_request");

            migrationBuilder.AlterColumn<string>(
                name: "Identification_number",
                table: "hrm_emp_identifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Identification_number",
                table: "hrm_emp_identifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End_Date",
                table: "hrm_emp_hmo_change_request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "hrm_emp_hmo_change_request",
                type: "datetime2",
                nullable: true);
        }
    }
}
