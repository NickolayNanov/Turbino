namespace Turbino.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Application.Common.Interfaces;
    using Turbino.Domain.Entities;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TurbinoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TurbinoDbConnection")));

            services.AddScoped<ITurbinoDbContext>(provider => provider.GetService<TurbinoDbContext>());

            services.AddDefaultIdentity<TurbinoUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<TurbinoRole>()
                .AddEntityFrameworkStores<TurbinoDbContext>();
            

            services.AddScoped<ITurbinoDbContext>(provider => provider.GetService<TurbinoDbContext>());

            return services;
        }
    }
}