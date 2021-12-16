using Begge.Common.Reflections;
using Begge.Data;
using Begge.Services.Contracts;
using Begge.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Begge.Web.Infrastructure
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BeggeDBContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            var serviceTransientInterfaceType = typeof(ITransientService);
            var serviceSingletonInterfaceType = typeof(ISingletonService);
            var serviceScopedInterfaceType = typeof(IScopedService);

            var types = serviceTransientInterfaceType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.IsClass && !x.IsAbstract)
                .Select(x => new
                {
                    Service = x.GetInterface($"I{x.Name}"),
                    Implementation = x
                }
                )
                .Where(x => x.Service != null);

            foreach (var type in types)
            {
                if (type.Implementation.GetInterfaces().Contains(serviceTransientInterfaceType))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (type.Implementation.GetInterfaces().Contains(serviceSingletonInterfaceType))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (type.Implementation.GetInterfaces().Contains(serviceScopedInterfaceType))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }
            return services;
        }
    }
}
