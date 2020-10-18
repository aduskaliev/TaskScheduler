using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaskSchedulerDataHandler
{
    public class DataHandler
    {
        private static IServiceCollection _serviceCollection;
        //private List<TaskWrap>
        public static IServiceCollection ServiceCollection => _serviceCollection;

        public DataHandler(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }


    }
}
