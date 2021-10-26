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

namespace APIGateway.Handlers.Hrm.setup.high_school_subjects
{
    public class DownloadHighSchoolSubjectsQuery : IRequest<byte[]>
    {
        public class DownloadHighSchoolSubjectsQueryHandler : IRequestHandler<DownloadHighSchoolSubjectsQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadHighSchoolSubjectsQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadHighSchoolSubjectsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllHighSchoolSubjectsAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Subject");
                    dt.Columns.Add("Description");

                    var _setupList = domainList.Select(a => new hrm_setup_high_school_subjects_contract
                    {
                        Subject = a.Subject,
                        Description = a.Description,
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Subject"] = itemRow.Subject;
                            row["Description"] = itemRow.Description;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("HighSchoolSubjects");
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
