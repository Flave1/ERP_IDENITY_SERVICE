using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_language
{
    public class GetSingleEmpLanguage_Query : IRequest<hrm_emp_language_contract_resp>
    {
        public int EmpId { get; set; }
        public class GetSingleEmpLanguage_QueryHandler : IRequestHandler<GetSingleEmpLanguage_Query, hrm_emp_language_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setupRepo;

            public GetSingleEmpLanguage_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_language_contract_resp> Handle(GetSingleEmpLanguage_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_language_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_language.Where(e => e.Id == request.EmpId && e.Deleted == false).ToListAsync();
                var languageList = await _setupRepo.GetAllLanguagesAsync();
                response.employeeList = list.Select(x => new hrm_emp_language_contract
                {
                    Id = x.Id,
                    LanguageId = x.LanguageId,
                    Language = languageList.FirstOrDefault(m => m.Id == x.LanguageId)?.Language,
                    Reading_Rating = x.Reading_Rating,
                    Writing_Rating = x.Writing_Rating,
                    Speaking_Rating = x.Speaking_Rating,
                    Approval_status = x.Approval_status,
                    Approval_status_name = (x.Approval_status == 1) ? "Approved" : (x.Approval_status == 2) ? "Pending" : (x.Approval_status == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
