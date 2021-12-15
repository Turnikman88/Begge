using Begge.Data;
using Begge.Services.Contracts;
using Begge.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Begge.Web.Infrastructure
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BeggeDBContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBraintreeService, BraintreeService>();

            return services;
        }
    }
}
