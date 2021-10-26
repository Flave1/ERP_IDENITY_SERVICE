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

namespace APIGateway.Handlers.Hrm.setup.hospital_management
{
    public class GetAllHospitalManagement_Query : IRequest<hrm_setup_hospital_management_contract_resp>
    {
        public class GetAllHospitalManagement_QueryHandler : IRequestHandler<GetAllHospitalManagement_Query, hrm_setup_hospital_management_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly ISetupRepository _setup;
            private readonly IEmployeeRepository _employeeRepo;

            public GetAllHospitalManagement_QueryHandler(DataContext datacontext, ISetupRepository setup, IEmployeeRepository employeeRepo)
            {
                _dataContext = datacontext;
                _setup = setup;
                _employeeRepo = employeeRepo;
            }

            public async Task<hrm_setup_hospital_management_contract_resp> Handle(GetAllHospitalManagement_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_setup_hospital_management_contract_resp { Setuplist = new List<hrm_setup_hospital_management_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };

                var locationList = await _setup.GetAllHospitalManagementsAsync();
                var hmoList = await _setup.GetAllHMOAsync();
                var empHospitalList = await _employeeRepo.GetAllEmpHospitalAsync();
                response.Setuplist = locationList.Select(x => new hrm_setup_hospital_management_contract
                {
                    Id = x.Id,
                    Hospital = x.Hospital,
                    HmoId = x.HmoId,
                    HmoName = hmoList.FirstOrDefault(m => m.Id == x.HmoId)?.Hmo_name,
                    ContactPhoneNo = x.ContactPhoneNo,
                    Email = x.Email,
                    Address = x.Address,
                    Rating = Convert.ToDecimal(empHospitalList.Where(m => x.Id == m.HospitalId)?.Average(p => p?.HospitalRating)),
                    OtherComments = x.OtherComments

                }).ToList();

                response.Status.Message.FriendlyMessage = locationList.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
