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

namespace APIGateway.Handlers.Hrm.setup.gym_workouts
{
    public class DownloadGymWorkoutQuery : IRequest<byte[]>
    {
        public class DownloadGymWorkoutQueryHandler : IRequestHandler<DownloadGymWorkoutQuery, byte[]>
        {
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;

            public DownloadGymWorkoutQueryHandler(DataContext context, ISetupRepository setup)
            {
                _context = context;
                _setup = setup;
            }

            public async Task<byte[]> Handle(DownloadGymWorkoutQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] File = new byte[0];

                    var domainList = await _setup.GetAllGymWorkoutAsync();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Gym");
                    dt.Columns.Add("ContactPhoneNo");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Ratings");
                    dt.Columns.Add("OtherComments");

                    var _setupList = domainList.Select(a => new hrm_setup_gym_workouts_contract
                    {
                        Gym = a.Gym,
                        Contact_phone_number = a.Contact_phone_number,
                        Email = a.Email,
                        Address = a.Address,
                        Ratings = a.Ratings,
                        Other_comments = a.Other_comments
                    }).ToList();

                    if (_setupList.Count() > 0)
                    {
                        foreach (var itemRow in _setupList)
                        {
                            var row = dt.NewRow();
                            row["Gym"] = itemRow.Gym;
                            row["ContactPhoneNo"] = itemRow.Contact_phone_number;
                            row["Email"] = itemRow.Email;
                            row["Address"] = itemRow.Address;
                            row["Ratings"] = itemRow.Ratings;
                            row["OtherComments"] = itemRow.Other_comments;
                            dt.Rows.Add(row);
                        }

                        if (_setupList != null)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("GymWorkout");
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
