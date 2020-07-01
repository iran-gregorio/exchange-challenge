using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        private IFactorRepository _factorRepository;

        public ExchangeService(IFactorRepository factorRepository) =>
            _factorRepository = factorRepository;

        public string GetQuote()
        {
            return _factorRepository.GetFactor();
        }
    }
}
