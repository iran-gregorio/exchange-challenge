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
        private readonly string category = "Teste";
        private readonly string currency = "USD";
        private readonly decimal qty = 1;

        [Fact]
        public async Task GetQuoteWithSuccess()
        {
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
