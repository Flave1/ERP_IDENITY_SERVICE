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

namespace APIGateway.Handlers.Hrm.Employee.emp_qualification
{
    public class GetSingleEmpQualification_Query : IRequest<hrm_emp_qualification_contract_resp>
    {
        public int EmpId { get; set; }
        public class GetSingleEmpQualification_QueryHandler : IRequestHandler<GetSingleEmpQualification_Query, hrm_emp_qualification_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;

            public GetSingleEmpQualification_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setup)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _setup = setup;
            }

            public async Task<hrm_emp_qualification_contract_resp> Handle(GetSingleEmpQualification_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_qualification_contract_resp { employeeList = new List<hrm_emp_qualification_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _data.hrm_emp_qualification.Where(e => e.Id == request.EmpId && e.Deleted == false).ToListAsync();
                var gradeList = await _setup.GetAllAcademicGradeAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_qualification_contract
                {

                    Id = x.Id,
                    Certificate = x.Certificate,
                    Institution = x.Institution,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    GradeId = x.GradeId,
                    GradeName = gradeList.FirstOrDefault(m => m.Id == x.GradeId)?.Grade,
                    Attachment = x.Attachment,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Confirmed" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Unconfirmed" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
