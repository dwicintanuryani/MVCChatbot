using ChatBotMVC.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Helpers
{
    public class ConfigHelper
    {
        public static IConfigurationRoot _configuration;

        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    string environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                    IConfigurationBuilder builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    if (!string.IsNullOrEmpty(environmentVariable))
                    {
                        builder.AddJsonFile($"appsetings.{environmentVariable}.json", optional: false, reloadOnChange: true);
                    }

                    builder.AddEnvironmentVariables();

                    _configuration = builder.Build();
                }
                return _configuration;
            }
        }


        #region Methods

        /// <summary>
        /// get setting value based on key and subkey information
        /// </summary>
        /// <param name="MainKey"></param>
        /// <param name="SubKey"></param>
        /// <returns></returns>
        public static string GetSettingValue(string MainKey, string SubKey)
        {
            return Configuration.GetSection(MainKey).GetValue<string>(SubKey);
        }

        /// <summary>
        /// get setting value from section AppSettings in appsetings.json
        /// </summary>
        public static AppSettings Settings
        {
            get
            {
                return Configuration.GetSection("AppSettings").Get<AppSettings>();
            }
        }

        #endregion 
    }
}
