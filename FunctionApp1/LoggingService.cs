using logginglib;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
namespace FunctionApp1
{
    public class LoggingService
    {
        public Logger Init()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<Logger>();
            return logger;
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddConsole();
            })
               .Configure<LoggerFilterOptions>(options =>
               {
                   options.AddFilter<ConsoleLoggerProvider>(null, LogLevel.Debug);
               })
               .AddTransient<Logger>();
        }
    }

}

