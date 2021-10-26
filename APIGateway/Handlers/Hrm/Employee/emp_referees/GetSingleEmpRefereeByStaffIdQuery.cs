using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_referees
{
    public class GetSingleEmpRefereeByStaffId_Query : IRequest<hrm_emp_referees_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpRefereeByStaffId_QueryHandler : IRequestHandler<GetSingleEmpRefereeByStaffId_Query, hrm_emp_referees_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            public GetSingleEmpRefereeByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo)
            {
                _data = data;
                _employeeRepo = employeeRepo;
            }

            public async Task<hrm_emp_referees_contract_resp> Handle(GetSingleEmpRefereeByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_referees_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_referees.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                response.employeeList = list.Select(x => new hrm_emp_referees_contract
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Relationship = x.Relationship,
                    NumberOfYears = x.NumberOfYears,
                    Organization = x.Organization,
                    Address = x.Address,
                    ConfirmationReceived = x.ConfirmationReceived,
                    ConfirmationDate = x.ConfirmationDate,
                    RefereeFilePath = x.RefereeFilePath,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Approved" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
