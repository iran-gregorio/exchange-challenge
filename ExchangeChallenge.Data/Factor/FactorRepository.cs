using System;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Data.Factor
{
    public class FactorRepository : IFactorRepository
    {
        public string GetFactor()
        {
            return "ok1";
        }
    }
}
