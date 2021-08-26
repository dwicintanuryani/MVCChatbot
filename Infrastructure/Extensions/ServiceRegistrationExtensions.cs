using ChatBotMVC.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var appServices = typeof(Startup).Assembly.DefinedTypes
                                .Where(x => typeof(IServiceRegistration)
                                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                .Select(Activator.CreateInstance)
                                .Cast<IServiceRegistration>().ToList();

            appServices.ForEach(svc => svc.RegisterAppServices(services, configuration));
                                
        }
    }
}
