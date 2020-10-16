using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TaskSchedulerDataHandler.Services.Utility;

namespace TaskSchedulerDataHandler
{
    public class DataHandler
    {
        private readonly object _instance;
        private static List<string> _dataStorageParameters;
        private static IServiceCollection _serviceCollection;

        public static List<string> StorageParameters => _dataStorageParameters;
        public static IServiceCollection ServiceCollection => _serviceCollection;

        public DataHandler(IServiceCollection serviceCollection, List<string> dataStorageParameters)
        {
            _instance = new object();
            _serviceCollection = serviceCollection;
            _dataStorageParameters = dataStorageParameters;
            StartUp();
        }

        public void StartUp()
        {
            Configure();
            RegisterServices();
        }


        private void Configure()
        {
            _serviceCollection.AddSingleton(provider => new DataHandlerConfiguration(_serviceCollection, _dataStorageParameters));
            IServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<DataHandlerConfiguration>();
        }

        private void RegisterServices()
        {

        }
    }
}
