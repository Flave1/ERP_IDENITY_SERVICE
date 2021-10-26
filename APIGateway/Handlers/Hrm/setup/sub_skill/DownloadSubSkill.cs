using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Setup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.sub_skill
{
    public class DownloadSubSkillQuery : IRequest<byte[]>
    {
        public int JobTitleId { get; set; }
        public class DownloadSubSkillQueryHandler : IRequestHandler<DownloadSubSkillQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setupRepo;

            public DownloadSubSkillQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setupRepo = setup;
            }

            public async Task<byte[]> Handle(DownloadSubSkillQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _context.hrm_setup_sub_skill.Where(e => e.Job_details_Id == request.JobTitleId).ToListAsync();
                    var jobDetailsList = await _setupRepo.GetAllJobTitleAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Job_title");
                    dt.Columns.Add("Skill");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Weight");

                    var _setupList = domainList.Select(a => new hrm_setup_sub_skill_contract
                    {
                        Job_title = jobDetailsList.FirstOrDefault(m => m.Id == a.Job_details_Id)?.Job_title,
                        Skill = a.Skill,
                        Description = a.Description,
                        Weight = a.Weight
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Job_title"] = itemRow.Job_title;
                            row["Skill"] = itemRow.Skill;
                            row["Description"] = itemRow.Description;
                            row["Weight"] = itemRow.Weight;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Job_Sub_Skill");
                                ws.DefaultColWidth = 20;
                                ws.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.None);
                                File = pck.GetAsByteArray();
                            }
                        }
                    }
                    return File;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
