using APIGateway.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_hospital
{
    public class Download_hrm_emp_hospitalMeetingById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_hospitalMeetingById_QueryHandler : IRequestHandler<Download_hrm_emp_hospitalMeetingById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_hospitalMeetingById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_hospitalMeetingById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var meetingObj = _data.hrm_emp_hospital_meeting.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = meetingObj.FileUrl;
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
