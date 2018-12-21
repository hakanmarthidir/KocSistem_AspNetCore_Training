using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Startup_3_Environment_Classes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        //Classlar uzerinden bu ortamları yurutuyorsak asagidaki gibi bir ekleme yaparak ASPNETCORE_ENVIRONMENT a ne set edildi ise ona gore ilgili startup classını baslatacaktır. 
        // Set edilen isimle alakalı bir class bulunamaz ise Startup.cs calistirilir.
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup(assemblyName);
        }
    }
}
