using APIGateway.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_hmo
{
    public class Download_hrm_emp_HmoChangeRequestById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_HmoChangeRequestById_QueryHandler : IRequestHandler<Download_hrm_emp_HmoChangeRequestById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_HmoChangeRequestById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_HmoChangeRequestById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var hmoRequest = _data.hrm_emp_hmo_change_request.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = hmoRequest.FileUrl;
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    return fileBytes;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
