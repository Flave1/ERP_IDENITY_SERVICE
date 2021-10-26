using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using AutoMapper;
using GODP.APIsContinuation.DomainObjects.UserAccount;
using GODP.APIsContinuation.Repository.Interface.Admin;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.hrm_staff
{
    public class GetAllHrmStaffQuery : IRequest<hrm_staff_contract_resp>
    {
        public class GetAllHrmStaffQueryHandler : IRequestHandler<GetAllHrmStaffQuery, hrm_staff_contract_resp>
        {
            private readonly ILoggerService _logger;
            private readonly DataContext _dataContext;
            private readonly IAdminRepository _repo;
            private readonly UserManager<cor_useraccount> _userManager;
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepo;
            public GetAllHrmStaffQueryHandler(
                IAdminRepository adminRepository,
                ILoggerService loggerService,
                DataContext dataContext,
                UserManager<cor_useraccount> userManager,
                IMapper mapper,
                IEmployeeRepository employeeRepo)
            {
                _userManager = userManager;
                _logger = loggerService;
                _dataContext = dataContext;
                _repo = adminRepository;
                _employeeRepo = employeeRepo;
                _mapper = mapper;
            }

            public async Task<hrm_staff_contract_resp> Handle(GetAllHrmStaffQuery request, CancellationToken cancellationToken)
            {
                var responses = new hrm_staff_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var JobTitleList = _dataContext.hrm_setup_jobtitle.Where(x => x.Deleted == false).ToList();
                var JobGradeList = _dataContext.hrm_setup_jobgrade.Where(x => x.Deleted == false).ToList();
                var companystructureList = _dataContext.cor_companystructure.Where(c => c.Deleted == false).ToList();
                var StaffUserList = await _employeeRepo.GetAllHrmStaffAsync();
                var UserList = await _userManager.Users.Where(d => d.Deleted == false).ToListAsync();

                //var respList = new List<hrm_staff_contract_objects>();
                responses.employeeList = _mapper.Map<List<hrm_staff_contract_objects>>(StaffUserList);
                foreach (var item in responses.employeeList)
                {
                    item.JobTitleName = JobTitleList?.FirstOrDefault(x => item.JobTitle == x.Id)?.Job_title;
                    item.JobGradeName = JobGradeList.FirstOrDefault(x => x.Id == item.JobGrade)?.Job_grade;
                    item.ReportingTo = JobGradeList.FirstOrDefault(x => x.Id == item.JobGrade)?.Job_grade_reporting_to;
                    item.StaffOfficeName = companystructureList?.FirstOrDefault(x => x.CompanyStructureId == item.StaffOfficeId)?.Name;
                    item.UserName = UserList?.FirstOrDefault(d => d.StaffId == item.StaffId)?.UserName;
                    item.UserId = UserList?.FirstOrDefault(d => d.StaffId == item.StaffId)?.Id;
                }
                responses.Status.Message.FriendlyMessage = responses.employeeList.Count() == 0 ? "Search Complete! No Record Found" : null;
                responses.employeeList.ToList();
                return responses;
            }
        }
    }
}
