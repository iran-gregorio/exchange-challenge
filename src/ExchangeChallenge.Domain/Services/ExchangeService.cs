using System;
using System.Threading.Tasks;
using ExchangeChallenge.Domain.Interfaces;
using ExchangeChallenge.Domain.Models;
using Microsoft.Extensions.Logging;

namespace ExchangeChallenge.Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IFactorRepository _factorRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly ILogger<ExchangeService> _logger;

        public ExchangeService(
            IFactorRepository factorRepository,
            ITaxRepository taxRepository,
            ILogger<ExchangeService> logger)
        {
            _factorRepository = factorRepository;
            _taxRepository = taxRepository;
            _logger = logger;
        }

        public async Task<Exchange> GetQuote(string category, string currency, decimal qty)
        {
            _logger.LogInformation($"Calculando a conversão para {currency}. (qty = {qty})");

            var result = await Task.WhenAll(
                _factorRepository.GetFactor(currency),
                _taxRepository.GetTax(category));
            var factor = result[0];
            var tax = result[1];
            var total = Math.Round(qty * factor * (1 + tax), 2);

            _logger.LogInformation($"Resultado da conversão: {total}");

            return new Exchange
            {
                ValueRequested = qty,
                FactorApplied = factor,
                TaxApplied = tax,
                Total = total
            };
        }
    }
}
