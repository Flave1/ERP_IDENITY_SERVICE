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

namespace APIGateway.Handlers.Hrm.Employee.emp_language
{
	public class AddUpdate_hrm_emp_language_Command : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_language_CommandHandler : IRequestHandler<hrm_emp_language_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_language_CommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_language_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_language.Find(request.Id);
					if(item == null)
						item = new hrm_emp_language();
					item.LanguageId = request.LanguageId;
					item.Reading_Rating = request.Reading_Rating;
					item.Writing_Rating = request.Writing_Rating;
					item.Speaking_Rating = request.Speaking_Rating;
					item.Approval_status = request.Approval_status;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpLanguageAsync(item);

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
