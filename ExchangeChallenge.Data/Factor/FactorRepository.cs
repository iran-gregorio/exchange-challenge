using System.Net.Http;
using System.Threading.Tasks;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Data.Factor
{
    public class FactorRepository : IFactorRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FactorRepository(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<string> GetFactor()
        {
            var client = _httpClientFactory.CreateClient("ExchangeRates");
            var result = await client.GetStringAsync("latest");
            return result;
        }
    }
}
