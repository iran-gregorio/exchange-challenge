using System.Threading.Tasks;
using ExchangeChallenge.Domain.Interfaces;
using ExchangeChallenge.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExchangeChallenge.UnitTest.Services
{
    public class ExchangeServiceTest
    {
        [Fact]
        public async Task GetQuoteWithSuccess()
        {
            var category = "Teste";
            var currency = "USD";
            var qty = 1;

            var mockFactor = new Mock<IFactorRepository>();
            mockFactor.Setup(m => m.GetFactor(currency)).Returns(Task.FromResult(1.2m));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(m => m.GetTax(category)).Returns(Task.FromResult(.2m));

            var service = new ExchangeService(mockFactor.Object, mockTax.Object);
            var result = await service.GetQuote(category, currency, qty);

            result.Total.Should().Be(1.44m);
        }
    }
}
