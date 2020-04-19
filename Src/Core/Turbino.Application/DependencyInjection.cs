namespace Turbino.Application
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using AutoMapper;
    using MediatR;

    using Application.Common.Logging;
    using Turbino.Application.Common.CommonService;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<ICommonService, CommonService>();

            return services;
        }
    }
}
