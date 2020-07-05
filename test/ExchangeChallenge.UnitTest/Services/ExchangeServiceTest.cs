using System;
using System.Threading.Tasks;
using ExchangeChallenge.Domain.Exceptions;
using ExchangeChallenge.Domain.Interfaces;
using ExchangeChallenge.Domain.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
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
            mockFactor.Setup(
                m => m.GetFactor(currency)).Returns(Task.FromResult(1.2m));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(
                m => m.GetTax(category)).Returns(Task.FromResult(.2m));

            var loggerMock = new Mock<ILogger<ExchangeService>>();

            var service = new ExchangeService(
                mockFactor.Object,
                mockTax.Object,
                loggerMock.Object);
            var result = await service.GetQuote(category, currency, qty);

            result.Total.Should().Be(1.44m);
        }

        [Fact]
        public void GetQuote_FactorNotFound()
        {
            var mockFactor = new Mock<IFactorRepository>();
            mockFactor.Setup(
                m => m.GetFactor(currency)).Returns(Task.FromResult(.0m));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(
                m => m.GetTax(category)).Returns(Task.FromResult(.2m));

            var loggerMock = new Mock<ILogger<ExchangeService>>();

            var service = new ExchangeService(
                mockFactor.Object,
                mockTax.Object,
                loggerMock.Object);

            FluentActions.Invoking(() => service.GetQuote(category, currency, qty))
                .Should().Throw<FactorNotFoundException>();
        }

        [Fact]
        public void GetQuote_TaxNotFound()
        {
            var mockFactor = new Mock<IFactorRepository>();
            mockFactor.Setup(
                m => m.GetFactor(currency)).Returns(Task.FromResult(.2m));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(
                m => m.GetTax(category)).Returns(Task.FromResult(.0m));

            var loggerMock = new Mock<ILogger<ExchangeService>>();

            var service = new ExchangeService(
                mockFactor.Object,
                mockTax.Object,
                loggerMock.Object);

            FluentActions.Invoking(() => service.GetQuote(category, currency, qty))
                .Should().Throw<TaxNotFoundException>();
        }

        [Fact]
        public void GetQuote_FactorFail()
        {
            var mockFactor = new Mock<IFactorRepository>();
            mockFactor.Setup(
                m => m.GetFactor(currency)).Throws(new Exception("Fail"));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(
                m => m.GetTax(category)).Returns(Task.FromResult(.2m));

            var loggerMock = new Mock<ILogger<ExchangeService>>();

            var service = new ExchangeService(
                mockFactor.Object,
                mockTax.Object,
                loggerMock.Object);

            FluentActions.Invoking(() => service.GetQuote(category, currency, qty))
                .Should().Throw<ExchangeServiceException>();
        }

        [Fact]
        public void GetQuote_TaxFail()
        {
            var mockFactor = new Mock<IFactorRepository>();
            mockFactor.Setup(
                m => m.GetFactor(currency)).Returns(Task.FromResult(.2m));

            var mockTax = new Mock<ITaxRepository>();
            mockTax.Setup(
                m => m.GetTax(category)).Throws(new Exception("Fail"));

            var loggerMock = new Mock<ILogger<ExchangeService>>();

            var service = new ExchangeService(
                mockFactor.Object,
                mockTax.Object,
                loggerMock.Object);

            FluentActions.Invoking(() => service.GetQuote(category, currency, qty))
                .Should().Throw<ExchangeServiceException>();
        }
    }
}
