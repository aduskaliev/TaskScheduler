using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TaskScheduler.Services.Utiliity
{
    internal class FileLogger : ILogger
    {
        private string path;
        private static object _lock = new object();
        public FileLogger(string path)
        {
            this.path = path;
        }       
        
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(
                        path,
                        formatter(state, exception) + Environment.NewLine
                     );
                }                
            }
        }
    }
}
