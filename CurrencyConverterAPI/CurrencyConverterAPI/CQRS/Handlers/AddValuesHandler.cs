using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.CQRS.Commands;
using CurrencyConverter.Interfaces;
using MediatR;

namespace CurrencyConverter.CQRS.Handlers
{
    public class AddValuesHandler : IRequestHandler<AddValuesCommand.AddExchangeRateCommand, Unit>
    {
        private readonly IConversionRepository _repository;

        public AddValuesHandler(IConversionRepository repository) => _repository = repository;

        public async Task<Unit> Handle(AddValuesCommand.AddExchangeRateCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddExchangeRatesAsync(request.ExchangeRate);
            
            return Unit.Value;
        }
    }
}