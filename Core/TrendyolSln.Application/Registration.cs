using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Beheviors;
using TrendyolSln.Application.Exceptions;
using TrendyolSln.Application.Features.Products.Rules;


namespace TrendyolSln.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes()
                .Where(t=>t.IsSubclassOf(type)&&type!=t).ToList();
            foreach (var t in types)
            {
                services.AddTransient(t);
            }
            return services;
        }



    }
}
