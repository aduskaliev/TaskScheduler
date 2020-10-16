using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TaskSchedulerDataHandler.Services.Utility
{
    internal class DataHandlerConfiguration
    {
        private IServiceCollection _serviceCollection;
        private List<string> _storageParameters;

        public DataHandlerConfiguration(IServiceCollection serviceCollection, List<string> storageParameters)
        {
            _serviceCollection = serviceCollection;
            _storageParameters = storageParameters;
            Configure();
        }

        private void Configure()
        {
            string storeTo;
            string path;
            if (_storageParameters.Count >= 2)
            {
                storeTo = _storageParameters[0];
                path = _storageParameters[1];
            }
            else
            {
                throw new Exception("Incorrect or absent parameters for data storage. Please edit config.ini to resolve.");
            }
            switch (storeTo)
            {
                case "file":
                    _serviceCollection.AddSingleton<IDataProvider>(provider => new JSONDataProvider(path));
                    _serviceCollection.AddSingleton<IDataConverter>(provider => new JSONDataConverter());
                    break;
                default:
                    _serviceCollection.AddSingleton<IDataProvider>(provider => new JSONDataProvider(path));
                    _serviceCollection.AddSingleton<IDataConverter>(provider => new JSONDataConverter());
                    break;
            }
        }
    }
}
