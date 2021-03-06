﻿namespace Turbino.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ImageUploader>();
            return services;
        }
    }
}