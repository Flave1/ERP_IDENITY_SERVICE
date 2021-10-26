using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
using APIGateway.Repository.Interface.Setup;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.location
{
    public class DownloadLocationQuery : IRequest<byte[]>
    {
        public class DownloadLocationQueryHandler : IRequestHandler<DownloadLocationQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            private readonly ICommonRepository _commonRepository;

            public DownloadLocationQueryHandler(DataContext context, ISetupRepository setup, ICommonRepository commonRepository)
            {
                _context = context;
                _setup = setup;
                _commonRepository = commonRepository;
            }

            public async Task<byte[]> Handle(DownloadLocationQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllLocationsAsync();
                    var countryList = await _commonRepository.GetAllCountryAsync();
                    var stateList = await _commonRepository.GetAllStateAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Location");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("City");
                    dt.Columns.Add("StateName");
                    dt.Columns.Add("CountryName");
                    dt.Columns.Add("AdditionalInformation");

                    var _setupList = domainList.Select(a => new hrm_setup_location_contract
                    {
                        Location = a.Location,
                        Address = a.Address,
                        City = a.City,
                        StateName = stateList.FirstOrDefault(m => m.StateId == a.StateId)?.StateName,
                        CountryName = countryList.FirstOrDefault(m => m.CountryId == a.CountryId)?.CountryName,
                        AdditionalInformation = a.AdditionalInformation

                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Location"] = itemRow.Location;
                            row["Address"] = itemRow.Address;
                            row["City"] = itemRow.City;
                            row["StateName"] = itemRow.StateName;
                            row["CountryName"] = itemRow.CountryName;
                            row["AdditionalInformation"] = itemRow.AdditionalInformation;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Locations");
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
