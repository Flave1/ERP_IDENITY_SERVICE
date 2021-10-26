﻿using APIGateway.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_referees
{
    public class Download_hrm_emp_refereeById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_refereeById_QueryHandler : IRequestHandler<Download_hrm_emp_refereeById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_refereeById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_refereeById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var referee = _data.hrm_emp_referees.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = referee.RefereeFilePath;
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
