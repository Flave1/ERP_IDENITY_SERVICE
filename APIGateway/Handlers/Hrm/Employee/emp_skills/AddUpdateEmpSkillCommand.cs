using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_skills
{
	public class AddUpdate_hrm_emp_skillCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_skillCommandHandler : IRequestHandler<hrm_emp_skills_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly IWebHostEnvironment _hostEnvironment;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_skillCommandHandler(DataContext context, IEmployeeRepository empRepo, IWebHostEnvironment hostEnvironment, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_hostEnvironment = hostEnvironment;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_skills_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();

				var getSkill = _context.hrm_setup_sub_skill.FirstOrDefault(m => m.Id == request.SkillId);

				var fileName = getSkill.Skill + "_" + request.StaffId + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				var folderName = "HrmEmployeeFiles";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				var fullPath = Path.Combine(pathToSave, fileName);
				var dbPath = Path.Combine(folderName, fileName);
				using (var fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await request.SkillFile.CopyToAsync(fileStream);
				}

				try
				{
					var item = _context.hrm_emp_skills.Find(request.Id);
					if (item == null)
						item = new hrm_emp_skills();
					item.SkillId = request.SkillId;
					item.ExpectedScore = getSkill.Weight;
					item.ActualScore = request.ActualScore;
					item.ProofOfSkills = request.ProofOfSkills;
					item.ProofOfSkillsUrl = dbPath;
					item.ApprovalStatus = request.ApprovalStatus;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpSkillAsync(item);

					response.Employee_Id = item.Id;
					response.Status.IsSuccessful = true;
					response.Status.Message.FriendlyMessage = "Record saved successfully";
					return response;
				}
				catch (Exception e)
				{
					#region Log error to file 
					response.Status.Message.FriendlyMessage = "Error occured please contact the helpdesk!";
					response.Status.Message.TechnicalMessage = e.ToString();
					_logger.Error(e.ToString());
					return response;
					#endregion
				}
			}
		}
	}
}
