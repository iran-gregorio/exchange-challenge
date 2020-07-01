using System;
using ExchangeChallenge.Domain.Interfaces;

namespace ExchangeChallenge.Infra.Configurations
{
    public class CategoryConfigurations : ICategoryConfigurations
    {
        public string Collection
        {
            get
            {
                return Environment.GetEnvironmentVariable("CATEGORY_COLLECTION");
            }
        }

        public string ConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("CATEGORY_CONN_STRING");
            }
        }

        public string Database
        {
            get
            {
                return Environment.GetEnvironmentVariable("CATEGORY_DATABASE");
            }
        }
    }
}
