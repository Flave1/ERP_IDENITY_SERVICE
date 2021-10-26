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

namespace APIGateway.Handlers.Hrm.Employee.emp_hmo
{
    public class GetSingleEmpHmoByStaffId_Query : IRequest<hrm_emp_hmo_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpHmoByStaffId_QueryHandler : IRequestHandler<GetSingleEmpHmoByStaffId_Query, hrm_emp_hmo_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;

            public GetSingleEmpHmoByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setup)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _setup = setup;
            }

            public async Task<hrm_emp_hmo_contract_resp> Handle(GetSingleEmpHmoByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_hmo_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_hmo.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                var hmoList = await _setup.GetAllHMOAsync();
                response.employeeList = list.Select(x => new hrm_emp_hmo_contract
                {
                    Id = x.Id,
                    HmoId = x.HmoId,
                    HmoName = hmoList.FirstOrDefault(m => m.Id == x.HmoId)?.Hmo_name,
                    Hmo_rating = x.Hmo_rating,
                    ContactPhoneNo = x.ContactPhoneNo,
                    StartDate = x.StartDate,
                    End_Date = x.End_Date,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Confirmed" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Unconfirmed" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
