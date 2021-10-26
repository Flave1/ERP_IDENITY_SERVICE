using APIGateway.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_skills
{
    public class Download_hrm_emp_skillsById_Query : IRequest<byte[]>
    {
        public int EmpId { get; set; }
        public class Download_hrm_emp_skillsById_QueryHandler : IRequestHandler<Download_hrm_emp_skillsById_Query, byte[]>
        {
            private readonly DataContext _data;
            public Download_hrm_emp_skillsById_QueryHandler(DataContext data)
            {
                _data = data;
            }

            public async Task<byte[]> Handle(Download_hrm_emp_skillsById_Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var skill = _data.hrm_emp_skills.FirstOrDefault(e => e.Id == request.EmpId);

                    string filePath = skill.ProofOfSkillsUrl;
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
