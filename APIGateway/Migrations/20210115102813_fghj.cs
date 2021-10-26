using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Migrations
{
    public partial class fghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "hrm_emp_career");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "hrm_emp_assets");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "hrm_setup_gym_workouts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "hrm_emp_career",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "hrm_emp_assets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "hrm_setup_hospital_management",
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
                    Hospital = table.Column<string>(nullable: true),
                    HmoId = table.Column<int>(nullable: false),
                    ContactPhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    OtherComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_setup_hospital_management", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hrm_setup_location",
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
                    Location = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hrm_setup_location", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hrm_setup_hospital_management");

            migrationBuilder.DropTable(
                name: "hrm_setup_location");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "hrm_setup_gym_workouts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "hrm_emp_career");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "hrm_emp_assets");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "hrm_emp_career",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "hrm_emp_assets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
