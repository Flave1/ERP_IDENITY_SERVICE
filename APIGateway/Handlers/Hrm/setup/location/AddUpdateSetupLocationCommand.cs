using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.location
{
	public class AddUpdate_hrm_setup_LocationCommand : IRequest<hrm_setup_add_update_response>
	{
		public class AddUpdate_hrm_setup_LocationCommandHandler : IRequestHandler<hrm_setup_location_contract, hrm_setup_add_update_response>
		{
			private readonly DataContext _context;
			private readonly ISetupRepository _setupRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_setup_LocationCommandHandler(DataContext context, ISetupRepository setupRepo, ILoggerService logger)
			{
				_context = context;
				_setupRepo = setupRepo;
				_logger = logger;
			}

			public async Task<hrm_setup_add_update_response> Handle(hrm_setup_location_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_setup_add_update_response();
				try
				{
					var item = _context.hrm_setup_location.Find(request.Id);
					if (item == null)
						item = new hrm_setup_location();
					item.Location = request.Location;
					item.Address = request.Address;
					item.City = request.City;
					item.StateId = request.StateId;
					item.CountryId = request.CountryId;
					item.AdditionalInformation = request.AdditionalInformation;

					await _setupRepo.AddUpdateLocationAsync(item);

					response.Setup_id = item.Id;
					response.Status.IsSuccessful = true;
					response.Status.Message.FriendlyMessage = "Record saved successfully";
					return response;
				}
				catch (Exception e)
				{
					#region Log error to file 

					response.Status.Message.FriendlyMessage = e?.Message ?? e.InnerException?.Message;
					response.Status.Message.TechnicalMessage = e.ToString();
					_logger.Error(e.ToString());
					return response;
					#endregion
				}
			}
		}
	}
}
