using ExchangeChallenge.Data.Factor;
using ExchangeChallenge.Data.Tax;
using ExchangeChallenge.Domain.Interfaces;
using ExchangeChallenge.Infra.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeChallenge.Infra.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddSingleton<ICategoryConfigurations, CategoryConfigurations>();

            services.AddSingleton<IFactorRepository, FactorRepository>();
            services.AddSingleton<ITaxRepository, TaxRepository>();
            return services;
        }
    }
}
