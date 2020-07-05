using System;
namespace ExchangeChallenge.Domain.Exceptions
{
    public class TaxNotFoundException : Exception
    {
        public TaxNotFoundException(string message) : base(message) { }
    }
}
