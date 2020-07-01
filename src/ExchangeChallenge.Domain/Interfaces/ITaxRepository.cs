using System.Threading.Tasks;

namespace ExchangeChallenge.Domain.Interfaces
{
    public interface ITaxRepository
    {
        public Task<decimal> GetTax(string category);
    }
}
