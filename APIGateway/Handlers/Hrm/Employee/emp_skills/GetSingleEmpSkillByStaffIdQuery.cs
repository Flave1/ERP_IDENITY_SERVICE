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

namespace APIGateway.Handlers.Hrm.Employee.emp_skills
{
    public class GetSingleEmpSkillByStaffId_Query : IRequest<hrm_emp_skills_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpSkillByStaffId_QueryHandler : IRequestHandler<GetSingleEmpSkillByStaffId_Query, hrm_emp_skills_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;

            public GetSingleEmpSkillByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setup)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _setup = setup;
            }

            public async Task<hrm_emp_skills_contract_resp> Handle(GetSingleEmpSkillByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_skills_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_skills.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                var skillsList = await _setup.GetAllJobSkillsAsync();
                response.employeeList = list.Select(x => new hrm_emp_skills_contract
                {
                    Id = x.Id,
                    SkillId = x.SkillId,
                    SkillName = skillsList.FirstOrDefault(m => m.Id == x.SkillId)?.Skill,
                    ExpectedScore = x.ExpectedScore,
                    ActualScore = x.ActualScore,
                    ProofOfSkills = x.ProofOfSkills,
                    ProofOfSkillsUrl = x.ProofOfSkillsUrl,
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
