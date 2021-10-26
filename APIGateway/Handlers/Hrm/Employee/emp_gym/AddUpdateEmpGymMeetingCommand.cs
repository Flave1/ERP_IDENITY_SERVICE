using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_gym
{
	public class AddUpdate_hrm_emp_GymMeetingCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_GymMeetingCommandHandler : IRequestHandler<hrm_emp_gym_meeting_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_GymMeetingCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}
			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_gym_meeting_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();

				var getGym = _context.hrm_setup_gym_workouts.FirstOrDefault(m => m.Id == request.GymId);
				var fileName = getGym.Gym + "_" + request.StaffId + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				var folderName = "HrmEmployeeFiles";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				var fullPath = Path.Combine(pathToSave, fileName);
				var dbPath = Path.Combine(folderName, fileName);
				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await request.gymMeetingFile.CopyToAsync(fileStream);
				}

				try
				{
					var item = _context.hrm_emp_gym_meeting.Find(request.Id);
					if (item == null)
						item = new hrm_emp_gym_meeting();
					item.GymId = request.GymId;
					item.DateOfRequest = request.DateOfRequest;
					item.ProposedMeetingDate = request.ProposedMeetingDate;
					item.ReasonsForMeeting = request.ReasonsForMeeting;
					item.FileUrl = dbPath;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpGymMeetingAsync(item);

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
