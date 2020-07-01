using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExchangeChallenge.Data.Factor.Models;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Data.Factor
{
    public class FactorRepository : IFactorRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public FactorRepository(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<decimal> GetFactor(string currency)
        {
            var client = _httpClientFactory.CreateClient("ExchangeRates");
            var result = await client.GetAsync($"latest?base=BRL&symbols={currency}");
            var stream = await result.Content.ReadAsStreamAsync();
            var exchangeResult = await JsonSerializer.DeserializeAsync<ExchangeRatesResult>(stream, jsonSerializerOptions);
            return exchangeResult.Rates.FirstOrDefault(x => x.Key.Equals(currency)).Value;
        }
    }
}
