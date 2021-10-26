using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_assets
{
    public class GetSingleEmpAsset_Query : IRequest<hrm_emp_assets_contract_resp>
    {
        public int EmpId { get; set; }
        public class GetSingleEmpAsset_QueryHandler : IRequestHandler<GetSingleEmpAsset_Query, hrm_emp_assets_contract_resp>
        {
            private readonly DataContext _data;
            private readonly ISetupRepository _setupRepo;

            public GetSingleEmpAsset_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _data = data;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_assets_contract_resp> Handle(GetSingleEmpAsset_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_assets_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_assets.Where(e => e.Id == request.EmpId && e.Deleted == false).ToListAsync();
                var locationList = await _setupRepo.GetAllLocationsAsync();
                response.employeeList = list.Select(x => new hrm_emp_assets_contract
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

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
