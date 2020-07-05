using System;
namespace ExchangeChallenge.Domain.Exceptions
{
    public class FactorNotFoundException : Exception
    {
        public FactorNotFoundException(string message) : base(message) { }
    }
}
