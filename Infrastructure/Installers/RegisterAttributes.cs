using ChatBotMVC.Infrastructure.Attributes;
using ChatBotMVC.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Installers
{
    internal class RegisterAttributes : IServiceRegistration
    {
        /// <summary>
        /// Register service for attribute information 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ValidateModelStateAttribute>();
        }
    }
}
