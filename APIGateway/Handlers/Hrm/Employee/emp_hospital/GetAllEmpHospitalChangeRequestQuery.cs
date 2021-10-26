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

namespace APIGateway.Handlers.Hrm.Employee.emp_hospital
{
    public class GetAllEmp_Hospital_Change_Request_Query : IRequest<hrm_emp_hospital_change_request_contract_resp>
    {
        public class GetAllEmp_Hospital_Change_Request_QueryHandler : IRequestHandler<GetAllEmp_Hospital_Change_Request_Query, hrm_emp_hospital_change_request_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;
            private readonly IAdminRepository _adminRepo;

            public GetAllEmp_Hospital_Change_Request_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setup, IAdminRepository adminRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setup = setup;
                _adminRepo = adminRepo;
            }

            public async Task<hrm_emp_hospital_change_request_contract_resp> Handle(GetAllEmp_Hospital_Change_Request_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_hospital_change_request_contract_resp { employeeList = new List<hrm_emp_hospital_change_request_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpHospitalChangeRequestAsync();
                var staffList = await _adminRepo.GetAllStaffAsync();
                var hospitalList = await _setup.GetAllHospitalManagementsAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_hospital_change_request_contract
                {
                    Id = x.Id,
                    HospitalId = x.HospitalId,
                    ExistingHospital = hospitalList.FirstOrDefault(a => a.Id == x.HospitalId)?.Hospital,
                    SuggestedHospital = x.SuggestedHospital,
                    SuggestedHospitalName = hospitalList.FirstOrDefault(a => a.Id == x.SuggestedHospital)?.Hospital,
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
