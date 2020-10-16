using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TaskSchedulerDataHandler;

namespace TaskScheduler.Services.Utiliity
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
            ConfigureInterface();
            ConfigureDataHandler();
            ConfigureLogger();
            LogConfig();
        }

        private void ConfigureInterface()
        {
            string userInterface = _config.GetValue<string>("userInterface");

            switch (userInterface)
            {
                case "console":
                    _serviceCollection.AddSingleton<IUserInterface>(provider => new ConsoleInterface());
                    break;
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

            List<string> dataStorageParameters = new List<string>
            {
                storeData,
                pathToData
            };

            _serviceCollection.AddSingleton(provider => new DataHandler(_serviceCollection, dataStorageParameters));

            _configurationInfo.Append(
                $"storeData = {storeData}\n" +
                $"pathToData = {pathToData}\n"
            );
        }

        private void ConfigureLogger()
        {
            string
                logOutput = _config.GetValue<string>("logOutput"),
                pathToLog = _config.GetValue<string>("pathToLog");

            switch (logOutput)
            {
                case "file":
                    _serviceCollection.AddSingleton<Logger<Application>>(provider => FileLogFactory<Application>.CreateFileLog(pathToLog));
                    break;
                default:
                    _serviceCollection.AddSingleton<Logger<Application>>(provider => FileLogFactory<Application>.CreateFileLog(pathToLog));
                    break;
            }

            _configurationInfo.Append(
                $"logOutput = {logOutput}\n" +
                $"pathToLog = {pathToLog}\n"
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
