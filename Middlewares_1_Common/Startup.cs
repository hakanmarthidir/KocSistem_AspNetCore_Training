using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Middlewares_1_Common
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        //MIDDLEWARE
        //Middleware, istekleri ve cevapları ele alabilmek için uygulama pipeline nına monte edilen bir yazılımdır.
        //HttpHandlers ve HttpModules AspNetCore ile gittiğinden artık bu durumları Middleware ile yonetebiliyoruz.
        //Her bileşen,
        //Isteği, pipelinedaki bir sonraki bileşene geçirip geçirmeyecegini secer.Pipelinde daki bir sonraki middleware cagrılmadan once veya sonra işler gerceklestirilebilir.
        //Middlewareler Configure methodu içerisinde yonetilirler ve sıraya sokulurlar. Sıralama son derece onemlidir. 

        //Common Order--------
        //yaygın middleware sıralaması asagidaki gibidir. Bilincsizce bozulan sıralamalar performance kayıplarına neden olacaktır. Dikkatli olunması gereken bir yerdir. 

        //Exception/error handling
        //HTTP Strict Transport Security Protocol
        //HTTPS redirection
        //Static file server
        //Cookie policy enforcement
        //Authentication
        //Session
        //MVC



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //MIDDLEWARE 1 :
            //Asagidak middleware  istek mvc pipelinenına ulasmadan evvel calisir ve istegin headerlarına ilgili baslıgı ekler. 
            //Ardından bir sonraki middleware e gecer. Use methodu ile calistirildigi için bir sonraki middleware e gecme eylemi gosterir. 
            app.Use(async (context, next) =>
            {
                //BEFORE : 
                context.Response.Headers.Add("KocSistemHeader", "1234");
                await next.Invoke();
                //AFTER :                 
            });


            //MIDDLEWARE 2
            // bu middleware de ise istek kısa devre yaptırılır. ve mvc pipeline i hic bir zaman calismaz. 
            // run methodu ile kullanıldıgı için kısa devre yapılacaktır. 
            app.Run(async context => { await context.Response.WriteAsync("End of the way"); });

            //bu senaryoya gore mvc middleware i calismayacaktır. 
            app.UseMvc();
        }
    }
}
