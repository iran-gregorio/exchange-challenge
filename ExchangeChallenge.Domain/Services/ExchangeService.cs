﻿using System;
using System.Threading.Tasks;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IFactorRepository _factorRepository;
        private readonly ITaxRepository _taxRepository;

        public ExchangeService(
            IFactorRepository factorRepository,
            ITaxRepository taxRepository)
        {
            _factorRepository = factorRepository;
            _taxRepository = taxRepository;
        }

        public async Task<decimal> GetQuote(string category, string currency, decimal qty)
        {
            var result = await Task.WhenAll(
                _factorRepository.GetFactor(currency),
                _taxRepository.GetTax(category));
            var factor = result[0];
            var tax = result[1];
            return Math.Round(qty * factor * (1 + tax), 2);
        }
    }
}
