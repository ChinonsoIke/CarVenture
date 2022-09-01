using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarVenture
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(Environment.CurrentDirectory, "logs", "car_venture-important.log"), restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.File(Path.Combine(Environment.CurrentDirectory, "logs", "car_venture-.logs"), rollingInterval: RollingInterval.Day)
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
