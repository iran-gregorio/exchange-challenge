﻿using System.Threading.Tasks;

namespace ExchangeChallenge.Domain.Interfaces
{
    public interface IFactorRepository
    {
        public Task<decimal> GetFactor(string currency);
    }
}
