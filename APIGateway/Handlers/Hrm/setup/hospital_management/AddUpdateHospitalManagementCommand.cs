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

namespace APIGateway.Handlers.Hrm.setup.hospital_management
{
	public class AddUpdate_hrm_setup_HospitalManagementCommand : IRequest<hrm_setup_add_update_response>
	{
		public class AddUpdate_hrm_setup_HospitalManagementCommandHandler : IRequestHandler<hrm_setup_hospital_management_contract, hrm_setup_add_update_response>
		{
			private readonly DataContext _context;
			private readonly ISetupRepository _setupRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_setup_HospitalManagementCommandHandler(DataContext context, ISetupRepository setupRepo, ILoggerService logger)
			{
				_context = context;
				_setupRepo = setupRepo;
				_logger = logger;
			}

			public async Task<hrm_setup_add_update_response> Handle(hrm_setup_hospital_management_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_setup_add_update_response();
				try
				{
					var item = _context.hrm_setup_hospital_management.Find(request.Id);
					if (item == null)
						item = new hrm_setup_hospital_management();
					item.Hospital = request.Hospital;
					item.HmoId = request.HmoId;
					item.ContactPhoneNo = request.ContactPhoneNo;
					item.Email = request.Email;
					item.Address = request.Address;
					item.Rating = 0;
					item.OtherComments = request.OtherComments;
					

					await _setupRepo.AddUpdateHospitalManagementAsync(item);

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
