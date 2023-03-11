namespace AS2_WEB
{

    using Microsoft.Extensions.Logging;
    using System;
    public class ColoredConsoleLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ColoredConsoleLogger();
        }

        private class ColoredConsoleLogger : ILogger
        {
            private readonly object _lock = new object();

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                lock (_lock)
                {
                    var color = Console.ForegroundColor;

                    switch (logLevel)
                    {
                        case LogLevel.Trace:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case LogLevel.Debug:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case LogLevel.Information:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case LogLevel.Warning:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case LogLevel.Error:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case LogLevel.Critical:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                    }

                    Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] [{logLevel}] {formatter(state, exception)}");

                    Console.ForegroundColor = color;
                }
            }
        }


    }
}
