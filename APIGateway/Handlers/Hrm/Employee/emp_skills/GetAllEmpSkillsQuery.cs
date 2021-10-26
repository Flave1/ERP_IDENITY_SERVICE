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

namespace APIGateway.Handlers.Hrm.Employee.emp_skills
{
    public class GetAllEmp_Skills_Query : IRequest<hrm_emp_skills_contract_resp>
    {
        public class GetAllEmp_Skills_QueryHandler : IRequestHandler<GetAllEmp_Skills_Query, hrm_emp_skills_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;

            public GetAllEmp_Skills_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setup)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setup = setup;
            }

            public async Task<hrm_emp_skills_contract_resp> Handle(GetAllEmp_Skills_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_skills_contract_resp { employeeList = new List<hrm_emp_skills_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpSkillsAsync();
                var skillsList = await _setup.GetAllJobSkillsAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_skills_contract
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

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
