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

namespace APIGateway.Handlers.Hrm.setup.hmo
{
    public class DownloadHMOQuery : IRequest<byte[]>
    {
        public class DownloadHMOQueryHandler : IRequestHandler<DownloadHMOQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadHMOQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadHMOQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllHMOAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Hmo_name");
                    dt.Columns.Add("Hmo_code");
                    dt.Columns.Add("Contact_phone_number");
                    dt.Columns.Add("Contact_email");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Reg_date");
                    dt.Columns.Add("Rating");
                    dt.Columns.Add("Other_comments");




                    var _setupList = domainList.Select(a => new hrm_setup_hmo_contract
                    {
                        Hmo_name = a.Hmo_name,
                        Hmo_code = a.Hmo_code,
                        Contact_phone_number = a.Contact_phone_number,
                        Contact_email = a.Contact_email,
                        Address = a.Address,
                        Reg_date = a.Reg_date,
                        Rating = a.Rating,
                        Other_comments = a.Other_comments
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Hmo_name"] = itemRow.Hmo_name;
                            row["Hmo_code"] = itemRow.Hmo_code;
                            row["Contact_phone_number"] = itemRow.Contact_phone_number;
                            row["Contact_email"] = itemRow.Contact_email;
                            row["Address"] = itemRow.Address;
                            row["Reg_date"] = itemRow.Reg_date;
                            row["Rating"] = itemRow.Rating;
                            row["Other_comments"] = itemRow.Other_comments;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("HMO");
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
