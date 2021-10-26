using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_career
{
	public class AddUpdate_hrm_emp_careerCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_careerCommandHandler : IRequestHandler<hrm_emp_career_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_careerCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_career_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_career.Find(request.Id);
					if (item == null)
						 item = new hrm_emp_career();
					item.Job_GradeId = request.Job_GradeId;
					item.Job_titleId = request.Job_titleId;
					item.Job_type = request.Job_type;
					item.CountryId = request.CountryId;
					item.LocationId = request.LocationId;
					item.Office = request.Office;
					item.Line_Manager = request.Line_Manager;
					item.First_Level_Reviewer = request.First_Level_Reviewer;
					item.Second_Level_Reviewer = request.Second_Level_Reviewer;
					item.Start_month = request.Start_month;
					item.Start_year = request.Start_year;
					item.End_month = request.End_month;
					item.End_year = request.End_year;
					item.Approval_status = request.Approval_status;
					item.StaffId = request.StaffId;
					 await _empRepo.AddUpdateEmpCareerAsync(item);
					
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
