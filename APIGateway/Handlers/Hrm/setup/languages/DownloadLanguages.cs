using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Handlers.Hrm.setup.academic_discipline;
using APIGateway.Repository.Interface.Setup;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.languages
{
    public class DownloadLanguagesQuery : IRequest<byte[]>
    {
        public class DownloadLanguagesQueryHandler : IRequestHandler<DownloadLanguagesQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadLanguagesQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadLanguagesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllLanguagesAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Language");
                    dt.Columns.Add("Description");

                    var _setupList = domainList.Select(a => new hrm_setup_languages_contract
                    {
                        Language = a.Language,
                        Description = a.Description
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Language"] = itemRow.Language;
                            row["Description"] = itemRow.Description;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Languages");
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
