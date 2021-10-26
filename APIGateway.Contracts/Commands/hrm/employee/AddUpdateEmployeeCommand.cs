using APIGateway.Contracts.Response.HRM;
using GODPAPIs.Contracts.Response.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.Contracts.Commands.hrm.employee
{
    public class UpdateHrmStaffCommand : IRequest<hrm_staff_add_update_response>
    {
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int JobTitle { get; set; }
        public int JobGrade { get; set; }
        public DateTime DateOfJoin { get; set; }
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

        public string UserName { get; set; }
        public string UserStatus { get; set; }
        public string UserId { get; set; }
        public int AccessLevelId { get; set; }
        public int[] UserAccessLevels { get; set; }

        public string[] UserRoleNames { get; set; }
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
