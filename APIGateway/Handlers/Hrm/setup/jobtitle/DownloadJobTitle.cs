using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Setup;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.jobdetail
{
    public class DownloadJobTitleQuery : IRequest<byte[]>
    {
        public class DownloadJobTitleQueryHandler : IRequestHandler<DownloadJobTitleQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadJobTitleQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadJobTitleQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllJobTitleAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Job_title");
                    dt.Columns.Add("Job_description");
                    dt.Columns.Add("Skill");
                    dt.Columns.Add("SubSkills_description");
                    dt.Columns.Add("Weight");

                    var _setupList = domainList.Select(a => new hrm_setup_jobtitle_contract
                    {
                        Job_title = a.Job_title,
                        Job_description = a.Job_description,
                        Sub_Skills = _context.hrm_setup_sub_skill.Where(e => e.Job_details_Id == a.Id).Select(r => new hrm_setup_sub_skill_contract
                        {

                            Skill = r.Skill,
                            Description = r.Description,
                            Weight = r.Weight
                        }).ToList()

                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Job_title"] = itemRow.Job_title;
                            row["Job_description"] = itemRow.Job_description;
                            row["Skill"] = itemRow.Sub_Skills.Where(a => a.Job_details_Id == a.Id).Select(m => m.Skill);
                            row["SubSkills_description"] = itemRow.Sub_Skills.Where(a => a.Job_details_Id == a.Id).Select(m => m.Description);
                            row["Weight"] = itemRow.Sub_Skills.Where(a => a.Job_details_Id == a.Id).Select(m => m.Weight);
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("JobDetails");
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
