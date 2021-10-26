using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static APIGateway.Contracts.Response.HRM.hrm_staff_contract_objects;

namespace APIGateway.Contracts.Response.HRM
{

    public class hrm_staff_add_update_response
    {
        public hrm_staff_add_update_response()
        {
            Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() };
        }
        public int StaffId { get; set; }
        public APIResponseStatus Status { get; set; }

    }
    public class hrm_staff_contract_resp
    {
        public hrm_staff_contract_resp()
        {
            employeeList = new List<hrm_staff_contract_objects>();
        }

        public List<hrm_staff_contract_objects> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_staff_contract_objects
    {
        public hrm_staff_contract_objects()
        {
            UserAccessLevels = new List<int>();
            UserRoleIds = new List<string>();
            UserRoleNames = new List<string>();
        }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int JobTitle { get; set; }
        public int JobGrade { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string ReportingTo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Photo { get; set; }
        public decimal? StaffLimit { get; set; }
        public int? AccessLevel { get; set; }
        public int? StaffOfficeId { get; set; }
        public List<string> UserRoleIds { get; set; }
        public bool? UserStatus { get; set; }
        public string UserName { get; set; }

        public string UserId { get; set; }
        public int AccessLevelId { get; set; }
        public List<int> UserAccessLevels { get; set; }

        public List<string> UserRoleNames { get; set; }
        public string ExcelUserRoleNames { get; set; }
        //...............................
        public string JobTitleName { get; set; }
        public string JobGradeName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string StaffOfficeName { get; set; }
        public bool? Active { get; set; }
        public string UserAccessLevelsNames { get; set; }
        public string AccessNames { get; set; }
        public int ExcelLineNumber { get; set; }
        //...............................
        public bool IsHRAdmin { get; set; }
        public bool PPEAdmin { get; set; }
        public bool IsPandPAdmin { get; set; }
        public bool IsCreditAdmin { get; set; }
        public bool IsInvestorFundAdmin { get; set; }
        public bool IsDepositAdmin { get; set; }
        public bool IsTreasuryAdmin { get; set; }
        public bool IsExpenseManagementAdmin { get; set; }
        public bool IsFinanceAdmin { get; set; }
    }
}
