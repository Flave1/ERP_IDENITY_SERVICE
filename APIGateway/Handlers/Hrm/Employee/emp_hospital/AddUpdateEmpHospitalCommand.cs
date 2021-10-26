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

namespace APIGateway.Handlers.Hrm.Employee.emp_hospital
{
	public class AddUpdate_hrm_emp_HospitalCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_HospitalCommandHandler : IRequestHandler<hrm_emp_hospital_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_HospitalCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_hospital_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_hospital.Find(request.Id);
					var getHospital = _context.hrm_setup_hospital_management.FirstOrDefault(m => m.Id == request.HospitalId);
					if (item == null)
						item = new hrm_emp_hospital();
					item.HospitalId = request.HospitalId;
					item.HospitalRating = request.HospitalRating;
					item.ContactPhoneNo = request.ContactPhoneNo;
					item.StartDate = request.StartDate;
					item.EndDate = request.EndDate;
					item.ApprovalStatus = request.ApprovalStatus;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpHospitalAsync(item);

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
