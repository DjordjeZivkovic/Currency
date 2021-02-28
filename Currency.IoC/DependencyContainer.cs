using Currency.Application.Inputs.Validators.ExchangeRateValidators;
using Currency.Application.Interfaces;
using Currency.Application.Services.ExchangeService;
using Currency.Infrastructure.Processors;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Currency.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLibraries(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetExchangeRates.QueryHandler).Assembly);
            services.AddAutoMapper(typeof(GetExchangeRates.QueryHandler).Assembly);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExchangeProcessor, ExchangeProcessor>();

            return services;
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(val =>
            {
                val.RegisterValidatorsFromAssemblyContaining<ExchangeRateValidator>();
            });

            return services;
        }
    }
}
