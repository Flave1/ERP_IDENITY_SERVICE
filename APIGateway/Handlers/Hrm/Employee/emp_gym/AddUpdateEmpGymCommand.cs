using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_gym
{
	public class AddUpdate_hrm_emp_GymCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_GymCommandHandler : IRequestHandler<hrm_emp_gym_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_GymCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_gym_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_gym.Find(request.Id);
					var getGym = _context.hrm_setup_gym_workouts.FirstOrDefault(m => m.Id == request.GymId);
					if (item == null)
						item = new hrm_emp_gym();
					item.GymId = request.GymId;
					item.GymRating = getGym.Ratings;
					item.GymContactPhoneNo = request.GymContactPhoneNo;
					item.StartDate = request.StartDate;
					item.End_Date = request.End_Date;
					item.ApprovalStatus = request.ApprovalStatus;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpGymAsync(item);

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
