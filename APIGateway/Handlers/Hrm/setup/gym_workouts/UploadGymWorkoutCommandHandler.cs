using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Setup;
using GODPAPIs.Contracts.GeneralExtension;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.gym_workouts
{
    public class UploadGymWorkoutCommand : IRequest<FileUploadRespObj>
    {
        public class UploadGymWorkoutCommandHandler : IRequestHandler<UploadGymWorkoutCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            public UploadGymWorkoutCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _context = context;
                _setup = setup;
            }

            public async Task<FileUploadRespObj> Handle(UploadGymWorkoutCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };


                List<hrm_setup_gym_workouts_contract> uploadedRecord = new List<hrm_setup_gym_workouts_contract>();
                var files = _accessor.HttpContext.Request.Form.Files;

                var byteList = new List<byte[]>();
                foreach (var fileBit in files)
                {
                    if (fileBit.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await fileBit.CopyToAsync(ms);
                            byteList.Add(ms.ToArray());
                        }
                    }
                }

                try
                {
                    if (byteList.Count() > 0)
                    {
                        foreach (var item in byteList)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (MemoryStream stream = new MemoryStream(item))
                            using (ExcelPackage excelPackage = new ExcelPackage(stream))
                            {
                                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];
                                int totalRows = workSheet.Dimension.Rows;
                                int totalColumns = workSheet.Dimension.Columns;
                                if (totalColumns != 6)
                                {
                                    response.Status.Message.FriendlyMessage = $"Six (6) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_gym_workouts_contract
                                    {
                                        ExcelLineNumber = i,
                                        Gym = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Contact_phone_number = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        Email = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        Address = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : null,
                                        Ratings = workSheet.Cells[i, 5].Value != null ? Convert.ToInt32(workSheet.Cells[i, 4].Value.ToString()) : 0,
                                        Other_comments = workSheet.Cells[i, 6].Value != null ? workSheet.Cells[i, 6].Value.ToString() : null,
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Status.Message.FriendlyMessage = $" {ex?.Message}";
                    return response;
                }

                try
                {
                    if (uploadedRecord.Count > 0)
                    {
                        foreach (var item in uploadedRecord)
                        {
                            if (string.IsNullOrEmpty(item.Gym))
                            {
                                response.Status.Message.FriendlyMessage = $"Gym cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Contact_phone_number))
                            {
                                response.Status.Message.FriendlyMessage = $"Contact_PhoneNumber cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Email))
                            {
                                response.Status.Message.FriendlyMessage = $"Email cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Address))
                            {
                                response.Status.Message.FriendlyMessage = $"Address cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Ratings < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Ratings cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Other_comments))
                            {
                                response.Status.Message.FriendlyMessage = $"Other_comments cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }

                            var current_item = _context.hrm_setup_gym_workouts.FirstOrDefault(e => e.Gym.ToLower() == item.Gym.ToLower());
                            if (current_item == null)
                            {
                                current_item = new hrm_setup_gym_workouts();
                                current_item.Gym = item.Gym;
                                current_item.Contact_phone_number = item.Contact_phone_number;
                                current_item.Email = item.Email;
                                current_item.Address = item.Address;
                                current_item.Ratings = item.Ratings;
                                current_item.Other_comments = item.Other_comments;
                                await _setup.AddUpdateGymWorkoutAsync(current_item);
                            }
                            else
                            {
                                current_item.Gym = item.Gym;
                                current_item.Contact_phone_number = item.Contact_phone_number;
                                current_item.Email = item.Email;
                                current_item.Address = item.Address;
                                current_item.Ratings = item.Ratings;
                                current_item.Other_comments = item.Other_comments;
                                await _setup.AddUpdateGymWorkoutAsync(current_item);
                            }
                        }
                    }
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = "Record saved successfully";
                    return response;
                }
                catch (Exception ex)
                {
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = ex?.Message;
                    return response;
                }
            }
        }
    }
}
