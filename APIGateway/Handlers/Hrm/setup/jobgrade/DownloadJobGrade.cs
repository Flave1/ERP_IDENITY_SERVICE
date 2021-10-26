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

namespace APIGateway.Handlers.Hrm.setup.jobgrade
{
    public class DownloadJobGradeQuery : IRequest<byte[]>
    {
        public class DownloadJobGradeQueryHandler : IRequestHandler<DownloadJobGradeQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadJobGradeQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadJobGradeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllJobGradesAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Job_grade");
                    dt.Columns.Add("Job_grade_reporting_to");
                    dt.Columns.Add("Rank");
                    dt.Columns.Add("Probation_period_in_months");
                    dt.Columns.Add("Description");

                    var _setupList = domainList.Select(a => new hrm_setup_jobgrade_contract
                    {
                        Job_grade = a.Job_grade,
                        Job_grade_reporting_to = a.Job_grade_reporting_to,
                        Rank = a.Rank,
                        Probation_period_in_months = a.Probation_period_in_months,
                        Description = a.Description
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Job_grade"] = itemRow.Job_grade;
                            row["Job_grade_reporting_to"] = itemRow.Job_grade_reporting_to;
                            row["Rank"] = itemRow.Rank;
                            row["Probation_period_in_months"] = itemRow.Probation_period_in_months;
                            row["Description"] = itemRow.Description;

                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("JobGrades");
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
