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

namespace APIGateway.Handlers.Hrm.setup.high_school_grade
{
    public class DownloadHighSchoolGradeQuery : IRequest<byte[]>
    {
        public class DownloadHighSchoolGradeQueryHandler : IRequestHandler<DownloadHighSchoolGradeQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadHighSchoolGradeQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadHighSchoolGradeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllHighSchoolGradesAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Grade");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Rank");

                    var _setupList = domainList.Select(a => new hrm_setup_high_school_grade_contract
                    {
                        Grade = a.Grade,
                        Description = a.Description,
                        Rank = a.Rank
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Grade"] = itemRow.Grade;
                            row["Description"] = itemRow.Description;
                            row["Rank"] = itemRow.Rank;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("HighSchoolGrades");
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
