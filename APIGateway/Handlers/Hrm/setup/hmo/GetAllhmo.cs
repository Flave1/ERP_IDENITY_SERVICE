using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.jobdetail
{
    public class GetAll_hrm_setup_hmo_Query : IRequest<hrm_setup_hmo_contract_resp>
    {
        public class GetAll_hrm_setup_hmo_QueryHandler : IRequestHandler<GetAll_hrm_setup_hmo_Query, hrm_setup_hmo_contract_resp>
        { 
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;

            public GetAll_hrm_setup_hmo_QueryHandler(DataContext data, IEmployeeRepository employeeRepo)
            {
                _data = data;
                _employeeRepo = employeeRepo;
            }
            public async Task<hrm_setup_hmo_contract_resp> Handle(GetAll_hrm_setup_hmo_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_setup_hmo_contract_resp { Setuplist = new List<hrm_setup_hmo_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var sol = await _data.hrm_setup_hmo.ToListAsync();
                var empHmoList = await _employeeRepo.GetAllEmpHmoAsync();
                response.Setuplist = sol.Select(a => new hrm_setup_hmo_contract
                {
                    Id = a.Id,
                    Reg_date = a.Reg_date,
                    Rating = Convert.ToDecimal(empHmoList.Where(m => a.Id == m.HmoId)?.Average(p => p?.Hmo_rating)),
                    Other_comments = a.Other_comments,
                    Hmo_name = a.Hmo_name,
                    Hmo_code = a.Hmo_code,
                    Contact_phone_number = a.Contact_phone_number,
                    Address = a.Address,
                    Contact_email = a.Contact_email
                }).ToList();

                response.Status.Message.FriendlyMessage = sol.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }

}
