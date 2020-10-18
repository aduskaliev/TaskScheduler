using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Services.Utility
{
    internal class IniConfiguration
    {
        public static Configuration ConfigurationBuilder(IServiceCollection serviceCollection, string pathToConfig)
        {
            return new Configuration(
                        serviceCollection,
                        new ConfigurationBuilder()
                            .AddIniFile(pathToConfig)
                            .Build()
                    );
        }
    }
}
