using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Configuration_2_InMemory
{
    public class Program
    {

        private static Dictionary<string, string> arrayDict = new Dictionary<string, string>
        {
            {"ApplicationName", "KocSistem"},
            {"Department", "R&D_InMemory"}            
        };

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

            .ConfigureAppConfiguration((hostingcontext, config) => {
                config.AddInMemoryCollection(arrayDict);
            })
                .UseStartup<Startup>();
    }
}
