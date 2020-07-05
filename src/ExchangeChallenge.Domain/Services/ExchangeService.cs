using System;
using System.Threading.Tasks;
using ExchangeChallenge.Domain.Exceptions;
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
            try
            {
                _logger.LogInformation($"Calculando a conversão para {currency}. (qty = {qty})");

                var result = await Task.WhenAll(
                    _factorRepository.GetFactor(currency),
                    _taxRepository.GetTax(category));
                var factor = result[0];

                if (factor == 0)
                    throw new FactorNotFoundException($"Fator não encontrado para a moeda {currency}.");

                var tax = result[1];

                if (tax == 0)
                    throw new TaxNotFoundException($"Taxa não encontrado para a categoria {category}.");

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
            catch (TaxNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            catch (FactorNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "Houve um erro inesperado";
                _logger.LogError(ex, message);
                throw new ExchangeServiceException($"{message}: {ex.Message}", ex.InnerException);
            }
        }
    }
}
