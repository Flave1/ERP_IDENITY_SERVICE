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

namespace APIGateway.Handlers.Hrm.Employee.emp_hobbies
{
    public class GetSingleEmpHobbyByStaffId_Query : IRequest<hrm_emp_hobbies_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpHobbyByStaffId_QueryHandler : IRequestHandler<GetSingleEmpHobbyByStaffId_Query, hrm_emp_hobbies_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            public GetSingleEmpHobbyByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo)
            {
                _data = data;
                _employeeRepo = employeeRepo;
            }

            public async Task<hrm_emp_hobbies_contract_resp> Handle(GetSingleEmpHobbyByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_hobbies_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_hobbies.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                response.employeeList = list.Select(x => new hrm_emp_hobbies_contract
                {
                    Id = x.Id,
                    HobbyName = x.HobbyName,
                    Description = x.Description,
                    Rating = x.Rating,
                    ApprovalStatus = x.ApprovalStatus,
                    Approval_status_name = (x.ApprovalStatus == 1) ? "Approved" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
