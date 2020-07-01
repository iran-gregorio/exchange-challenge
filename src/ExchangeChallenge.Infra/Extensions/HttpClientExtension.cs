using System;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ExchangeChallenge.Infra.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClients(
            this IServiceCollection services)
        {
            services.AddHttpClient("ExchangeRates", x =>
            {
                x.BaseAddress = new Uri(Environment.GetEnvironmentVariable("EXCHANGE_RATES_URL"));
            }).AddTransientHttpErrorPolicy(
                p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)))
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            return services;
        }
    }
}
