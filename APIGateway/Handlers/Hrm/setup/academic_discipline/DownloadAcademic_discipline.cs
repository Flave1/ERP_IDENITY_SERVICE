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

namespace APIGateway.Handlers.Hrm.setup.academic_discipline
{
    public class DownloadAcademicDisciplineQuery: IRequest<byte[]>
    {
        public class DownloadAcademicDisciplineQueryHandler : IRequestHandler<DownloadAcademicDisciplineQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadAcademicDisciplineQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }
            public async Task<byte[]> Handle(DownloadAcademicDisciplineQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllAcademicDisciplineAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Discipline");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Rank");

                    var _setupList = domainList.Select(a => new hrm_setup_academic_discipline_contract
                    {
                        Discipline = a.Discipline,
                        Description = a.Description,
                        Rank = a.Rank
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Discipline"] = itemRow.Discipline;
                            row["Description"] = itemRow.Description;
                            row["Rank"] = itemRow.Rank;
                            dt.Rows.Add(row);
                        }

                        if (_setupList.Any())
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Academic Disciplines");
                                ws.DefaultColWidth = 20;
                                ws.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.None);
                                File = pck.GetAsByteArray();
                            }
                        }
                    }
                    return File;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
        }

    }
}
