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

namespace APIGateway.Handlers.Hrm.Employee.emp_identification
{
    public class GetSingleEmpIdentificationByStaffId_Query : IRequest<hrm_emp_identification_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpIdentificationByStaffId_QueryHandler : IRequestHandler<GetSingleEmpIdentificationByStaffId_Query, hrm_emp_identification_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;

            public GetSingleEmpIdentificationByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo)
            {
                _data = data;
                _employeeRepo = employeeRepo;
            }

            public async Task<hrm_emp_identification_contract_resp> Handle(GetSingleEmpIdentificationByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_identification_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_identifications.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                response.employeeList = list.Select(x => new hrm_emp_Identification_contract
                {
                    Id = x.Id,
                    Identification = x.Identification,
                    Identification_number = x.Identification_number,
                    IdIssues = x.IdIssues,
                    IdExpiry_date = x.IdExpiry_date,
                    IdentificationFilePath = x.IdentificationFilePath,
                    Approval_status = x.Approval_status,
                    Approval_status_name = (x.Approval_status == 1) ? "Approved" : (x.Approval_status == 2) ? "Pending" : (x.Approval_status == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
