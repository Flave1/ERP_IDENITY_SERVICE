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

namespace APIGateway.Handlers.Hrm.Employee.emp_hospital
{
	public class AddUpdate_hrm_emp_HospitalChangeRequestCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_HospitalChangeRequestCommandHandler : IRequestHandler<hrm_emp_hospital_change_request_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_HospitalChangeRequestCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}
			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_hospital_change_request_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();

				var getHospital = _context.hrm_setup_hospital_management.FirstOrDefault(m => m.Id == request.HospitalId);

				var fileName = getHospital.Hospital + "_" + request.StaffId + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				var folderName = "HrmEmployeeFiles";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				var fullPath = Path.Combine(pathToSave, fileName);
				var dbPath = Path.Combine(folderName, fileName);
				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await request.hospitalFile.CopyToAsync(fileStream);
				}

				try
				{
					var item = _context.hrm_emp_hospital_change_request.Find(request.Id);
					if (item == null)
						item = new hrm_emp_hospital_change_request();
					item.HospitalId = request.HospitalId;
					item.SuggestedHospital = request.SuggestedHospital;
					item.DateOfRequest = request.DateOfRequest;
					item.ExpectedDateOfChange = request.ExpectedDateOfChange;
					item.ApprovalStatus = request.ApprovalStatus;
					item.FileUrl = dbPath;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpHospitalChangeRequestAsync(item);

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
