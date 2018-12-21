using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Configuration_1_JsonFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //Json dosyasını hedef olarak gosterelim. 
             .ConfigureAppConfiguration((hostingcontext, config) => {
                 //Json Ekleme
                 //config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                 //Ini File Ekleme
                 //config.AddIniFile("myconfig.ini", optional: false, reloadOnChange: false);
                 //Xml File Ekleme
                 //config.SetBasePath(Directory.GetCurrentDirectory());
                 config.AddXmlFile("appsettings.xml", optional: false, reloadOnChange: false);
             })
                .UseStartup<Startup>();
    }
}
