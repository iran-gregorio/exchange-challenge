using System.Threading.Tasks;

namespace ExchangeChallenge.Domain.Interfaces
{
    public interface IExchangeService
    {
        public Task<string> GetQuote(string userId, string category, string currency);
    }
}
