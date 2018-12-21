using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Logging_1_Common
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             //LOG CONFIGURATION
             .ConfigureLogging((hostingContext, logging) =>
             {
                 //daha once tanımlanmıs providerlar var ise temizliyor
                 logging.ClearProviders();
                 //configuration ayarlarını ilgili dokumandan alıyor. appsettings.json
                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 // debug logger provider eklendi. farklı providerlar eklenerek farklı noktalara cıktılar eklenebilir. Output windowdan logları gorebiliriz. 
                 logging.AddDebug();
             })

                .UseStartup<Startup>();
    }
}
