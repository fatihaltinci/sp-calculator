using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SPCalculator.Service.FluentValidations;
using SPCalculator.Service.Services.Abstractions;
using SPCalculator.Service.Services.Concretes;
using System.Reflection;

namespace SPCalculator.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services) // 
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<ISprintService, SprintService>(); // ISprintService interface'ini SprintService class'ına bağladık. Her ISprintService istendiğinde SprintService class'ı çağırılacak.
            services.AddScoped<IFunctionService, FunctionService>(); // IFunctionService interface'ini FunctionService class'ına bağladık. Her IFunctionService istendiğinde FunctionService class'ı çağırılacak.
            services.AddScoped<IParameterService, ParameterService>(); // IParameterService interface'ini ParameterService class'ına bağladık. Her IParameterService istendiğinde ParameterService class'ı çağırılacak.
            services.AddScoped<IHomeService, HomeService>(); // IHomeService interface'ini HomeService class'ına bağladık. Her IHomeService istendiğinde HomeService class'ı çağırılacak.


            services.AddAutoMapper(assembly); // AutoMapper'ı projeye dahil ettik

            services.AddControllersWithViews().AddFluentValidation(opt => 
            {
            opt.RegisterValidatorsFromAssemblyContaining<SprintValidator>(); // FluentValidation'ı projeye dahil ettik
            opt.DisableDataAnnotationsValidation = true; // [] yapısındaki validation'ları devre dışı bıraktık
            });

            return services;
        }
    }
}
