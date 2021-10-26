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

namespace APIGateway.Handlers.Hrm.setup.hospital_management
{
    public class DownloadHospitalManagementQuery : IRequest<byte[]>
    {
        public class DownloadHospitalManagementQueryHandler : IRequestHandler<DownloadHospitalManagementQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadHospitalManagementQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadHospitalManagementQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllHospitalManagementsAsync();
                    var hmoList = await _setup.GetAllHMOAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Hospital");
                    dt.Columns.Add("HmoName");
                    dt.Columns.Add("ContactPhoneNo");
                    dt.Columns.Add("ContactEmail");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Rating");
                    dt.Columns.Add("OtherComments");

                    var _setupList = domainList.Select(a => new hrm_setup_hospital_management_contract
                    {
                        Hospital = a.Hospital,
                        HmoName = hmoList.FirstOrDefault(m => m.Id == a.HmoId)?.Hmo_name,
                        ContactPhoneNo = a.ContactPhoneNo,
                        Email = a.Email,
                        Address = a.Address,
                        Rating = a.Rating,
                        OtherComments = a.OtherComments

                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Hospital"] = itemRow.Hospital;
                            row["HmoName"] = itemRow.HmoName;
                            row["ContactPhoneNo"] = itemRow.ContactPhoneNo;
                            row["ContactEmail"] = itemRow.Email;
                            row["Address"] = itemRow.Address;
                            row["Rating"] = itemRow.Rating;
                            row["OtherComments"] = itemRow.OtherComments;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("HospitalManagement");
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
