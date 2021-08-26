using ChatBotMVC.Interface;
using DataAccess.DBConnection;
using DataAccess.Interface;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Installers
{
    internal class RegisterContractMapping : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Data Access Configuration
            services.AddSingleton<IUnitofWork, RepoSQLDBUnitofWork>();
            services.AddSingleton<IConnection, RepoSQLDBConnection>();


        }
    }
}
