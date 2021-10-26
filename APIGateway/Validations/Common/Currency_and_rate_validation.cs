using APIGateway.Contracts.Commands.Common;
using APIGateway.Data;
using FluentValidation; 
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Validations.Common
{
    public class Currency_and_rate_validation : AbstractValidator<AddUpdateCurrencyRateCommand>
    {
        private readonly DataContext _dataContext;
    public Currency_and_rate_validation(DataContext dataContext)
    {
        _dataContext = dataContext;
        RuleFor(e => e.CurrencyId).NotEmpty().WithMessage("Currency required");
        RuleFor(e => e.Date).NotEmpty().WithMessage("Date required"); 
        RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Dupliacte setup detected");
    }
    private async Task<bool> NoDuplicateAsync(AddUpdateCurrencyRateCommand request, CancellationToken cancellationToken)
    {
        request.Date = request.Date.AddDays(1);
        if (request.CurrencyRateId > 0)
        {
            var item = _dataContext.cor_currencyrate.FirstOrDefault(e => e.Date.Date == request.Date.Date && e.CurrencyId == request.CurrencyId && e.CurrencyRateId != request.CurrencyRateId && e.Deleted == false);
            if (item != null)
            {
                return await Task.Run(() => false);
            }
            return await Task.Run(() => true);
        }
        if (_dataContext.cor_currencyrate.Count(e => e.Date.Date == request.Date.Date && e.CurrencyId == request.CurrencyId && e.Deleted == false) >= 1)
        {
            return await Task.Run(() => false);
        }
        return await Task.Run(() => true);
    }
}
}
