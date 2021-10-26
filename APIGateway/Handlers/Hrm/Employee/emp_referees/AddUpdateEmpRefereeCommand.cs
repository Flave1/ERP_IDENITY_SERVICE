using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_referees
{
	public class AddUpdate_hrm_emp_refereeCommand : IRequest<hrm_emp_add_update_response>
	{
		public class Add_update_hrm_emp_refereeCommandHandler : IRequestHandler<hrm_emp_referees_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly IWebHostEnvironment _hostEnvironment;
			private readonly ILoggerService _logger;

			public Add_update_hrm_emp_refereeCommandHandler(DataContext context, IEmployeeRepository empRepo, IWebHostEnvironment hostEnvironment, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_hostEnvironment = hostEnvironment;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_referees_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();

				var fileName = request.FullName + "_" + request.StaffId + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				var folderName = "HrmEmployeeFiles";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				var fullPath = Path.Combine(pathToSave, fileName);
				var dbPath = Path.Combine(folderName, fileName);
				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await request.RefereeFile.CopyToAsync(fileStream);
				}

				try
				{
					var item = _context.hrm_emp_referees.Find(request.Id);
					if(item == null)
						item = new hrm_emp_referees();
					item.FullName = request.FullName;
					item.PhoneNumber = request.PhoneNumber;
					item.Email = request.Email;
					item.Relationship = request.Relationship;
					item.NumberOfYears = request.NumberOfYears;
					item.Organization = request.Organization;
					item.Address = request.Address;
					item.ConfirmationReceived = request.ConfirmationReceived;
					item.ConfirmationDate = request.ConfirmationDate;
					item.RefereeFilePath = dbPath;
					item.ApprovalStatus = request.ApprovalStatus;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpRefereeAsync(item);

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
