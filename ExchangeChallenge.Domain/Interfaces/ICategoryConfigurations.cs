using System;
namespace ExchangeChallenge.Domain.Interfaces
{
    public interface ICategoryConfigurations
    {
        public string Collection { get; }
        public string ConnectionString { get; }
        public string Database { get; }
    }
}
