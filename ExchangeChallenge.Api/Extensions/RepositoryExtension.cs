using ExchangeChallenge.Data.Factor;
using ExchangeChallenge.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeChallenge.Api.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddSingleton<IFactorRepository, FactorRepository>();
            return services;
        }
    }
}
