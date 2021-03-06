﻿using System;
using Microsoft.Extensions.DependencyInjection;
using TaskScheduler.Services.Utility;

namespace TaskScheduler
{
    public class Application
    {
        public void Run(IServiceCollection serviceCollection)
        {
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IUserInterface userInterface = serviceProvider.GetService<IUserInterface>();
            userInterface.Run();
        }
    }
}
