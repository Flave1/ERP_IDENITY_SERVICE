using APIGateway.Contracts.Commands.Email;
using APIGateway.Contracts.Response.Email;
using APIGateway.Data;
using APIGateway.DomainObjects.Company;
using GODP.APIsContinuation.Repository.Interface.Admin;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Common
{

	public class AddUpdateEmailConfigCommandHandler : IRequestHandler<AddUpdateEmailConfigCommand, SendEmailRespObj>
	{
		private readonly DataContext _dataContext;
		private readonly IAdminRepository _repo;
		public AddUpdateEmailConfigCommandHandler(DataContext dataContext, IAdminRepository repository)
		{
			_dataContext = dataContext;
			_repo = repository;
		}
		public async Task<SendEmailRespObj> Handle(AddUpdateEmailConfigCommand request, CancellationToken cancellationToken)
		{
			try
			{

				var item = _dataContext.cor_emailconfig.Find(request.EmailConfigId);
				if (item == null)
					item = new cor_emailconfig();

				item.EmailConfigId = request.EmailConfigId;
				item.BaseFrontend = request.BaseFrontend;
				item.EnableSSL = request.EnableSSL;
				item.SenderEmail = request.SenderEmail;
				item.MailCaption = request.MailCaption;
				item.SenderPassword = request.SenderPassword;
				item.SenderUserName = request.SenderUserName;
				item.SendNotification = request.SendNotification;
				item.SmtpClient = request.SmtpClient;
				item.SMTPPort = request.SMTPPort;

				await _repo.AddUpdateEmailConfigAsync(item);

				return new SendEmailRespObj { ResponseStatus = item.EmailConfigId, Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } } };

			}
			catch (Exception ex)
			{
				#region Log error to file 
				return new SendEmailRespObj
				{

					Status = new APIResponseStatus
					{
						IsSuccessful = false,
						Message = new APIResponseMessage
						{
							FriendlyMessage = "Error occured!! Unable to process request",
							TechnicalMessage = $"{ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}"
						}
					}
				};
				#endregion
			}
		}
	}

}
