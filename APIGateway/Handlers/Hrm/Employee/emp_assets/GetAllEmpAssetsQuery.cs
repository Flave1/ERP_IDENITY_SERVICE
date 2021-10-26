using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_assets
{
    public class GetAllEmp_Assets_Query : IRequest<hrm_emp_assets_contract_resp>
    {
        public class GetAllEmp_Assets_QueryHandler : IRequestHandler<GetAllEmp_Assets_Query, hrm_emp_assets_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setupRepo;

            public GetAllEmp_Assets_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_assets_contract_resp> Handle(GetAllEmp_Assets_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_assets_contract_resp { employeeList = new List<hrm_emp_assets_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpAssetsAsync();
                var locationList = await _setupRepo.GetAllLocationsAsync();

                response.employeeList = emp_List.Select(x => new hrm_emp_assets_contract
                {
                    Id = x.Id,
                    AssetName = x.AssetName,
                    AssetNumber = x.AssetNumber,
                    Description = x.Description,
                    Classification = x.Classification,
                    PhysicalCondition = x.PhysicalCondition,
                    LocationId = x.LocationId,
                    LocationName = locationList.FirstOrDefault(m => m.Id == x.LocationId)?.Location,
                    RequestApprovalStatus = x.RequestApprovalStatus,
                    RequestApprovalStatusName = (x.RequestApprovalStatus == 1) ? "Approved" : (x.RequestApprovalStatus == 2) ? "Pending" : (x.RequestApprovalStatus == 3) ? "Declined" : null,
                    ReturnApprovalStatus = x.ReturnApprovalStatus,
                    ReturnApprovalStatusName = (x.ReturnApprovalStatus == 1) ? "Approved" : (x.ReturnApprovalStatus == 2) ? "Pending" : (x.ReturnApprovalStatus == 3) ? "Declined" : (x.ReturnApprovalStatus == 4) ? "Not Returned" : null,
                    StaffId = x.StaffId

                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
