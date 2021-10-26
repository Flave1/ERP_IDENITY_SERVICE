using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.sub_skill
{
    public class GetAll_hrm_setup_subskill_Query : IRequest<hrm_setup_sub_skill_contract_resp>
    {
        public class GetAll_hrm_setup_subskill_QueryHandler : IRequestHandler<GetAll_hrm_setup_subskill_Query, hrm_setup_sub_skill_contract_resp>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setupRepo;
            public GetAll_hrm_setup_subskill_QueryHandler(DataContext context, ISetupRepository setupRepo)
            {
                _context = context;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_setup_sub_skill_contract_resp> Handle(GetAll_hrm_setup_subskill_Query request, CancellationToken cancellationToken)
            {
                var jobDetailsList = await _setupRepo.GetAllJobTitleAsync();
                var response = new hrm_setup_sub_skill_contract_resp { Setuplist = new List<hrm_setup_sub_skill_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var setup = await _context.hrm_setup_sub_skill.ToListAsync();
                response.Setuplist = setup.Select(a => new hrm_setup_sub_skill_contract
                {
                    Id = a.Id,
                    Skill = a.Skill,
                    Description = a.Description,
                    Weight = a.Weight,
                    Job_details_Id = a.Job_details_Id,
                    Job_title = jobDetailsList.FirstOrDefault(m => m.Id == a.Job_details_Id)?.Job_title
                }).ToList();

                response.Status.Message.FriendlyMessage = setup.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
