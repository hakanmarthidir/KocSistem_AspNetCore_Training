using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Configuration_3_Environment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //Program cs den json veya benzer filelar hedef olarak gosterilecek ise asagidaki sekilde environmentlara gore ilgili dosya gosterilebilir.        

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            
            .ConfigureAppConfiguration((hostingcontext, config) => {
                IHostingEnvironment env = hostingcontext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                //Istenirse spesifik olarak dosya yoluda belirtilebilir. Yada yukarıdaki gibi dinamik olarak belirtilebiir.
                //config.AddJsonFile("appsettings.Staging.json");
                //config.AddJsonFile("appsettings.Production.json");
                //config.AddJsonFile("appsettings.Development.json");
            })
            .UseStartup<Startup>();

    }
}
