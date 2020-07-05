using System;
namespace ExchangeChallenge.Domain.Exceptions
{
    public class ExchangeServiceException : Exception
    {
        public ExchangeServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
