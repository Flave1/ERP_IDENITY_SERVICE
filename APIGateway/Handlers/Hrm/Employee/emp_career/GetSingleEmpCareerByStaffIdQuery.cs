using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
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

namespace APIGateway.Handlers.Hrm.Employee.emp_career
{
    public class GetSingleEmpCareerByStaffId_Query : IRequest<hrm_emp_career_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpCareerByStaffId_QueryHandler : IRequestHandler<GetSingleEmpCareerByStaffId_Query, hrm_emp_career_contract_resp>
        {
            private readonly DataContext _data;
            private readonly ISetupRepository _setupRepo;
            private readonly ICommonRepository _commonRepository;

            public GetSingleEmpCareerByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setupRepo, ICommonRepository commonRepository)
            {
                _data = data;
                _setupRepo = setupRepo;
                _commonRepository = commonRepository;
            }

            public async Task<hrm_emp_career_contract_resp> Handle(GetSingleEmpCareerByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_career_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_career.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                var jobTitleList = await _setupRepo.GetAllJobTitleAsync();
                var jobGradeList = await _setupRepo.GetAllJobGradesAsync();
                var countryList = await _commonRepository.GetAllCountryAsync();
                var locationList = await _setupRepo.GetAllLocationsAsync();

                response.employeeList = list.Select(x => new hrm_emp_career_contract
                {
                    Id = x.Id,
                    Job_GradeId = x.Job_GradeId,
                    Job_Grade = jobGradeList.FirstOrDefault(m => m.Id == x.Job_GradeId)?.Job_grade,
                    Job_titleId = x.Job_titleId,
                    Job_title = jobTitleList.FirstOrDefault(m => m.Id == x.Job_titleId)?.Job_title,
                    Job_type = x.Job_type,
                    CountryId = x.CountryId,
                    CountryName = countryList.FirstOrDefault(m => m.CountryId == x.CountryId)?.CountryName,
                    LocationId = x.LocationId,
                    LocationName = locationList.FirstOrDefault(m => m.Id == x.LocationId)?.Location,
                    Office = x.Office,
                    Line_Manager = x.Line_Manager,
                    First_Level_Reviewer = x.First_Level_Reviewer,
                    Second_Level_Reviewer = x.Second_Level_Reviewer,
                    Start_date = (x.Start_month + x.Start_year),
                    Start_month = x.Start_month,
                    Start_year = x.Start_year,
                    End_month = x.End_month,
                    End_year = x.End_year,
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
