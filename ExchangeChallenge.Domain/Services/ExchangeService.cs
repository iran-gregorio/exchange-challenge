using System.Threading.Tasks;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        private IFactorRepository _factorRepository;

        public ExchangeService(IFactorRepository factorRepository) =>
            _factorRepository = factorRepository;

        public async Task<string> GetQuote(string userId, string category)
        {
            return await _factorRepository.GetFactor();
        }
    }
}
