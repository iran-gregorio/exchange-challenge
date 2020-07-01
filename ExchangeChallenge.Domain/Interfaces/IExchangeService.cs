using System.Threading.Tasks;
using ExchangeChallenge.Domain.Models;

namespace ExchangeChallenge.Domain.Interfaces
{
    public interface IExchangeService
    {
        public Task<Exchange> GetQuote(string category, string currency, decimal qty);
    }
}
