using APIGateway.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_gym
{
    public class Download_hrm_emp_gymMeetingById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_gymMeetingById_QueryHandler : IRequestHandler<Download_hrm_emp_gymMeetingById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_gymMeetingById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_gymMeetingById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var gymMeetingObj = _data.hrm_emp_gym_meeting.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = gymMeetingObj.FileUrl;
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