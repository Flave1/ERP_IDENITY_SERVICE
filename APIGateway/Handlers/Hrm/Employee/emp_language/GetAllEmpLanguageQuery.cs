using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_language
{
    public class GetAllEmp_Language_Query : IRequest<hrm_emp_language_contract_resp>
    {
        public class GetAllEmp_Language_QueryHandler : IRequestHandler<GetAllEmp_Language_Query, hrm_emp_language_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setupRepo;

            public GetAllEmp_Language_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_language_contract_resp> Handle(GetAllEmp_Language_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_language_contract_resp { employeeList = new List<hrm_emp_language_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpLanguageAsync();
                var languageList = await _setupRepo.GetAllLanguagesAsync();

                response.employeeList = emp_List.Select(x => new hrm_emp_language_contract
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

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;

            }
        }
    }
}
