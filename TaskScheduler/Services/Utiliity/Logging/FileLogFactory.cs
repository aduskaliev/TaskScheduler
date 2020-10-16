using Microsoft.Extensions.Logging;

namespace TaskScheduler.Services.Utiliity
{
    internal static class FileLogFactory<T>
    {
        public static Logger<T> CreateFileLog(string pathToLog) =>
            (Logger<T>) LoggerFactory.Create(builder =>
                {   
                    builder
                      .AddProvider(new FileLoggerProvider(pathToLog))
                      ;
                }
            ).CreateLogger<T>();
    }
}
