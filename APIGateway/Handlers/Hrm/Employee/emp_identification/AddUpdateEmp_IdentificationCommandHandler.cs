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

namespace APIGateway.Handlers.Hrm.Employee.emp_identification
{
	public class AddUpdate_hrm_emp_identicationCommand : IRequest<hrm_emp_add_update_response>
	{
		public class Add_update_hrm_emp_identificationCommandHandler : IRequestHandler<hrm_emp_Identification_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly IWebHostEnvironment _hostEnvironment;
			private readonly ILoggerService _logger;

			public Add_update_hrm_emp_identificationCommandHandler(DataContext context, IEmployeeRepository empRepo, IWebHostEnvironment hostEnvironment, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_hostEnvironment = hostEnvironment;
				_logger = logger;
			}


			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_Identification_contract request, CancellationToken cancellationToken)
			{

				var response = new hrm_emp_add_update_response();

				var fileName = request.Identification + "_" + request.StaffId + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				var folderName = "HrmEmployeeFiles";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				var fullPath = Path.Combine(pathToSave, fileName);
				var dbPath = Path.Combine(folderName, fileName);
				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await request.IdenticationFile.CopyToAsync(fileStream);
				}

				try
				{
					var item = _context.hrm_emp_identifications.Find(request.Id);
					if (item == null)
						 item = new hrm_emp_identification();
					item.Identification = request.Identification;
					item.Identification_number = request.Identification_number;
					item.IdIssues = request.IdIssues;
					item.IdExpiry_date = request.IdExpiry_date;
					item.IdentificationFilePath = dbPath;
					item.Approval_status = request.Approval_status;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpIdentificationAsync(item);

					response.Employee_Id = item.Id;


					response.Status.IsSuccessful = true;
					response.Status.Message.FriendlyMessage = "Record saved successfully";
					return response;
				}
				catch (Exception e)
				{
					#region Log error to file 
					response.Status.Message.FriendlyMessage = "Error occured, please contact helpdesk!";
					response.Status.Message.TechnicalMessage = e.ToString();
					_logger.Error(e.ToString());
					return response;
					#endregion
				}
			}
		}
	}
}
