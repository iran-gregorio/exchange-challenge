using ExchangeChallenge.Domain.Interfaces;
using ExchangeChallenge.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeChallenge.Infra.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddSingleton<IExchangeService, ExchangeService>();
            return services;
        }
    }
}
