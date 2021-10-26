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

namespace APIGateway.Handlers.Hrm.setup.proffessional_certification
{
    public class DownloadProf_CertificationQuery : IRequest<byte[]>
    {
        public class DownloadProf_CertificationQueryHandler : IRequestHandler<DownloadProf_CertificationQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadProf_CertificationQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadProf_CertificationQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllProfCertificationsAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Certification");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Rank");

                    var _setupList = domainList.Select(a => new hrm_setup_proffessional_certification_contract
                    {
                        Certification = a.Certification,
                        Description = a.Description,
                        Rank = a.Rank
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Certification"] = itemRow.Certification;
                            row["Description"] = itemRow.Description;
                            row["Rank"] = itemRow.Rank;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Professional_Certification");
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
