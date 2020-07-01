using System.Threading.Tasks;

namespace ExchangeChallenge.Domain.Interfaces
{
    public interface IExchangeService
    {
        public Task<decimal> GetQuote(string category, string currency, decimal qty);
    }
}
