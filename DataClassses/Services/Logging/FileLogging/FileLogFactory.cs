using Microsoft.Extensions.Logging;

namespace SharedClasses.Services.Logging
{
    public static class FileLogFactory<T>
    {
        public static ILogger<T> CreateFileLog(string pathToLog) =>
            LoggerFactory.Create(builder =>
                {   
                    builder
                      .AddProvider(new FileLoggerProvider(pathToLog))
                      ;
                }
            ).CreateLogger<T>();
    }
}
