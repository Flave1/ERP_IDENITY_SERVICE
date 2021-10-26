using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_emergency_contact
{
	public class AddUpdate_hrm_emp_emergency_contactCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_emergency_contactCommandHandler : IRequestHandler<hrm_emp_emergency_contact_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_emergency_contactCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_emergency_contact_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_emergency_contact.Find(request.Id);
					if(item == null)
						item = new hrm_emp_emergency_contact();
					item.FullName = request.FullName;
					item.Contact_phone_number = request.Contact_phone_number;
					item.Email = request.Email;
					item.Relationship = request.Relationship;
					item.Address = request.Address;
					item.CountryId = request.CountryId;
					item.Approval_status = request.Approval_status;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpEmergencyContactAsync(item);

					response.Employee_Id = item.Id;
					response.Status.IsSuccessful = true;
					response.Status.Message.FriendlyMessage = "Record saved successfully";
					return response;


				}
				catch (Exception e)
				{
					#region Log error to file 
					response.Status.Message.FriendlyMessage = "Error Occurred !! Please contact help desk";
					response.Status.Message.TechnicalMessage = e.ToString();
					_logger.Error(e.ToString());
					return response;
					#endregion
				}
			}
		}
	}
}
