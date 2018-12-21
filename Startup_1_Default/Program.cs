using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Startup_1_Default
{
    public class Program
    {

        // Main method, CreateWebHostBuilderi tetikler. burası da bir web host yaratır. IIS aktif ise iis uzerinden calisir.
        // web serveri tanımlayabilmek için bazı methodları vardır. isteginize gore sekillendirebilirsiniz. UseIIS, UseKestrel, UseSockets gibi..
        // Uygulama ayaga kalkarken hangi pipelineı ve serviceleri kullanacak ise UseStartup methodu içerisinde kullanılan class yardımı ile kendini configure eder. 
        // UseStartup<Startup>()

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)            
                .UseStartup<Startup>();
    }
}
