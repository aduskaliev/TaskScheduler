using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedClasses.Interfaces;
using SharedClasses.Services.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TaskScheduler.Services.Utility;
using TaskScheduler.Services.Utility.Data;

namespace TaskScheduler.Services.Utility
{
    public class Configuration
    {
        internal IConfiguration _config;
        internal IServiceCollection _serviceCollection;

        private static StringBuilder _configurationInfo;
        public static StringBuilder ConfigInfo { get => _configurationInfo; }

        static Configuration()
        {
            _configurationInfo = new StringBuilder();
        }

        public Configuration(IServiceCollection serviceCollection, IConfiguration config)
        {            
            this._config = config;
            this._serviceCollection = serviceCollection;
            Configure();
        }

        /*
         * implement service replacement mechanism
        internal void Reconfigure(IConfiguration config)
        {
            this._config = config;
            Configure();
        }
        */

        private void Configure()
        {
            ConfigureLogger();
            ConfigureInterface();
            ConfigureDataHandler();            
            LogConfig();
        }

        private void ConfigureLogger()
        {
            string
                logOutput = _config.GetValue<string>("logOutput"),
                pathToLog = _config.GetValue<string>("pathToLog");

            switch (logOutput)
            {
                case "file":
                default:
                    _serviceCollection.AddSingleton<ILogger<Application>>(provider => FileLogFactory<Application>.CreateFileLog(pathToLog));
                    break;
            }

            _configurationInfo.Append(
                $"logOutput = {logOutput}\n" +
                $"pathToLog = {pathToLog}\n"
            );
        }

        private void ConfigureInterface()
        {
            string userInterface = _config.GetValue<string>("userInterface");

            switch (userInterface)
            {
                case "console":
                default:
                    _serviceCollection.AddSingleton<IUserInterface>(provider => new ConsoleInterface());
                    break;
            }

            _configurationInfo.Append(
                $"userInterface = {userInterface}\n"
            );
        }

        private void ConfigureDataHandler()
        {
            string
                storeData = _config.GetValue<string>("storeData"),
                pathToData = _config.GetValue<string>("pathToData");

            if (String.IsNullOrEmpty(storeData) || String.IsNullOrEmpty(pathToData))
            {
                ILogger<Application> logger = _serviceCollection.BuildServiceProvider().GetService<ILogger<Application>>();
                logger.LogError(
                    $"{DateTime.Now}:\n" +
                    $"In class {this.GetType()}\n " +
                    $"method {MethodBase.GetCurrentMethod().Name}\n" +
                    $"was invoked with incorrect parameters.");
                throw new Exception("Incorrect or absent parameters for data storage. Please edit config.ini to resolve.");
            }
            
            switch (storeData)
            {
                case "file":
                default:
                    _serviceCollection.AddSingleton<IDataProvider>(provider => new JSONDataProvider(pathToData));
                    _serviceCollection.AddSingleton<IDataConverter>(provider => new JSONDataConverter());
                    _serviceCollection.AddSingleton<IIdGenerator>(provider => new InternalIdGenerator());
                    break;
            }

            _configurationInfo.Append(
                $"storeData = {storeData}\n" +
                $"pathToData = {pathToData}\n"
            );
        }        

        private void LogConfig()
        {
            StringBuilder startInfo = new StringBuilder(
                "-----\n" +
                $"{DateTime.Now}\n" +
                "TaskScheduler started with following pararmetets:\n" +
                $"{ConfigInfo}" +
                "-----"
            );

            IServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider();
            Logger<Application> logger = serviceProvider.GetService<Logger<Application>>();
            logger.LogInformation(startInfo.ToString());
        }
    }
}
