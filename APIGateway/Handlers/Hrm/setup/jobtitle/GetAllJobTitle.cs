using APIGateway.Contracts.Response.HRM;
using APIGateway.Contracts.Response.Modules;
using APIGateway.Data;
using APIGateway.DomainObjects.Modules;
using APIGateway.Repository.Interface.Setup;
using GODP.APIsContinuation.Repository.Interface;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.jobdetail
{
    public class GetAll_hrm_setup_jobtitle_Query : IRequest<hrm_setup_jobtitle_contract_resp>
    {
        public class GetAll_hrm_setup_jobtitle_QueryHandler : IRequestHandler<GetAll_hrm_setup_jobtitle_Query, hrm_setup_jobtitle_contract_resp>
        { 
            private readonly DataContext _data;
            private readonly ISetupRepository _setupRepo;
            public GetAll_hrm_setup_jobtitle_QueryHandler(DataContext data, ISetupRepository setupRepo)
            {
                _data = data;
                _setupRepo = setupRepo;
            }
            public async Task<hrm_setup_jobtitle_contract_resp> Handle(GetAll_hrm_setup_jobtitle_Query request, CancellationToken cancellationToken)
            {
                var SubSkillList = await _setupRepo.GetAllJobSkillsAsync();
                var response = new hrm_setup_jobtitle_contract_resp { Setuplist= new List<hrm_setup_jobtitle_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var sol = await _data.hrm_setup_jobtitle.ToListAsync();
                response.Setuplist = sol.Select(a => new hrm_setup_jobtitle_contract
                {
                    Id = a.Id,
                    Job_description = a.Job_description,
                    Job_title = a.Job_title,
                    TotalSkillWeight = Convert.ToDecimal(SubSkillList.Where(m => m.Job_details_Id == a.Id)?.Sum(p => p.Weight)),
                    Sub_Skills = _data.hrm_setup_sub_skill.Where(e => e.Job_details_Id == a.Id).Select(r => new hrm_setup_sub_skill_contract
                    {
                        Id = r.Id,
                        Job_details_Id = r.Job_details_Id,
                        Description = r.Description,
                        Skill = r.Skill,
                        Weight = r.Weight
                    }).ToList()
                }).ToList();

                response.Status.Message.FriendlyMessage = sol.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }

}
