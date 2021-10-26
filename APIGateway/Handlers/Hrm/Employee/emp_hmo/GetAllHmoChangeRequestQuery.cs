using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GODP.APIsContinuation.Repository.Interface.Admin;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_hmo
{
    public class GetAllEmp_Hmo_Change_Request_Query : IRequest<hrm_emp_hmo_change_request_contract_resp>
    {
        public class GetAllEmp_Hmo_Change_Request_QueryHandler : IRequestHandler<GetAllEmp_Hmo_Change_Request_Query, hrm_emp_hmo_change_request_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;
            private readonly IAdminRepository _adminRepo;

            public GetAllEmp_Hmo_Change_Request_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setup, IAdminRepository adminRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setup = setup;
                _adminRepo = adminRepo;
            }

            public async Task<hrm_emp_hmo_change_request_contract_resp> Handle(GetAllEmp_Hmo_Change_Request_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_hmo_change_request_contract_resp { employeeList = new List<hrm_emp_hmo_change_request_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpHmoChangeRequestAsync();
                var hmoList = await _setup.GetAllHMOAsync();
                var staffList = await _adminRepo.GetAllStaffAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_hmo_change_request_contract
                {
                    Id = x.Id,
                    HmoId = x.HmoId,
                    ExistingHmo = hmoList.FirstOrDefault(m => m.Id == x.HmoId)?.Hmo_name,
                    SuggestedHmo = x.SuggestedHmo,
                    SuggestedHmoName = hmoList.FirstOrDefault(m => m.Id == x.SuggestedHmo)?.Hmo_name,
                    DateOfRequest = x.DateOfRequest,
                    ExpectedDateOfChange = x.ExpectedDateOfChange,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Confirmed" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Unconfirmed" : null,
                    StaffId = x.StaffId,
                    StaffCode = staffList.FirstOrDefault(m => m.StaffId == x.StaffId).StaffCode
                    
                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
