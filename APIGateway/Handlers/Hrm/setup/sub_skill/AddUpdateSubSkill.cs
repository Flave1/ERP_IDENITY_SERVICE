using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using MediatR;
using System;
using System.Threading;
using APIGateway.DomainObjects.hrm;
using System.Threading.Tasks;
using System.Linq;
using APIGateway.Repository.Interface.Setup;

namespace APIGateway.Handlers.Hrm.setup.sub_skill
{
    public class Add_update_hrm_setup_sub_skill : IRequestHandler<hrm_setup_sub_skill_contract, hrm_setup_add_update_response>
    {
        private readonly DataContext _context;
        public Add_update_hrm_setup_sub_skill(DataContext context)
        {
            _context = context;

		}

        public async Task<hrm_setup_add_update_response> Handle(hrm_setup_sub_skill_contract request, CancellationToken cancellationToken)
        {
			var response = new hrm_setup_add_update_response();
			try
			{
				var currentItem = _context.hrm_setup_sub_skill.Find(request.Id);
				if (currentItem == null) currentItem = new hrm_setup_sub_skill();
				currentItem.Id = request.Id;
				currentItem.Skill = request.Skill;
				currentItem.Description = request.Description;
				currentItem.Weight = request.Weight;
				currentItem.Job_details_Id = request.Job_details_Id;

				if (currentItem.Id < 1)
					_context.hrm_setup_sub_skill.Add(currentItem);


			    _context.SaveChanges();
				response.Status.Message.FriendlyMessage = "Record saved successfully";
				response.Status.IsSuccessful = true;
				return response;			

			}
			catch (Exception e)
			{
				response.Status.Message.FriendlyMessage = "Error Occurred !! Please contact help desk";
				response.Status.Message.TechnicalMessage = e.ToString();
                return response;
			}
		}
    }
}
