using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_referees
{
    public class GetAllEmp_Referees_Query : IRequest<hrm_emp_referees_contract_resp>
    {
        public class GetAllEmp_Referees_QueryHandler : IRequestHandler<GetAllEmp_Referees_Query, hrm_emp_referees_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            public GetAllEmp_Referees_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
            }

            public async Task<hrm_emp_referees_contract_resp> Handle(GetAllEmp_Referees_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_referees_contract_resp { employeeList = new List<hrm_emp_referees_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpRefereesAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_referees_contract
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

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
