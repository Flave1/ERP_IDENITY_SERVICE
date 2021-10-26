using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using GOSLibraries.GOS_API_Response;

namespace APIGateway.Handlers.Hrm.Employee.emp_identification
{
    public class Download_hrm_emp_identificationById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_identificationById_QueryHandler : IRequestHandler<Download_hrm_emp_identificationById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_identificationById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_identificationById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var identification = _data.hrm_emp_identifications.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = identification.IdentificationFilePath;
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    return fileBytes;

                }
                catch(Exception ex)
                {

                    throw ex;
                }
                
            }

        }
    }
}
