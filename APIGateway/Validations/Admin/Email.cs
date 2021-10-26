using APIGateway.Contracts.Commands.Email;
using APIGateway.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Validations.Admin
{
    public class Email_validateion : AbstractValidator<AddUpdateEmailConfigCommand>
    {
        private readonly DataContext _dataContext;
        public Email_validateion(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.MailCaption).NotEmpty();
            RuleFor(e => e.SenderEmail).NotEmpty().WithMessage("Email required");
            RuleFor(e => e.SenderPassword).NotEmpty().WithMessage("Password required");
            RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Dupliacte setup detected");
        }
        private async Task<bool> NoDuplicateAsync(AddUpdateEmailConfigCommand request, CancellationToken cancellationToken)
        {
            if (request.EmailConfigId > 0)
            {
                var item = _dataContext.cor_emailconfig.FirstOrDefault(e => e.SenderEmail.ToLower() == request.SenderEmail.ToLower() && e.EmailConfigId != request.EmailConfigId && e.Deleted == false);
                if (item != null)
                {
                    return await Task.Run(() => false);
                }
                return await Task.Run(() => true);
            }
            if (_dataContext.cor_emailconfig.Count(e => e.SenderEmail.ToLower() == request.SenderEmail.ToLower() && e.Deleted == false) >= 1)
            {
                return await Task.Run(() => false);
            }
            return await Task.Run(() => true);
        }
    }
}
