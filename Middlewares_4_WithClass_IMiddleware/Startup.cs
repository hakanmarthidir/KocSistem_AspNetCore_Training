using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Middlewares_4_WithClass_IMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MiddlewareDbContext>(
                 options =>
                 options.UseInMemoryDatabase("headerlog", InMemoryDatabaseRoot));
            services.AddTransient<FactoryActivatedMiddleware>();
        }

        //Daha once yazdıgımız middleware yapısı Convention Based Middleware olarak gecer. 
        //Herhangi bir interface den implement edilmeden ve DI Containera register edilmeden calisan sistemlerdir. Genel kullanıma uygundur. 

        //IMIDDLEWARE 
        //Farklı bir sekilde daha Middleware olusturabiliriz. 
        //Bunun için IMiddleware interfaceini kullanabilir ve Middlewareimizi aktive edebilmek için devreye IMiddlewareFactory i koyarız. 
        // bu yontem interface tabanlı oldugu için strong typed bir yontemdir. aynı zamanda ihtiyac duydugumuz database context ve/veya diger servisleri ( scoped veya transient olarak register edilmisleri ) kullanmamıza imkan sunan bir yapıdadır. Injectionlarımızı ilgili middlewarein constructorunda yaparız. 

        //*** gelen requestlerin headerlarını ef core InMemory ozelligi ile kayıt altına aldık. 

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseFactoryActivatedMiddleware();
            app.UseMvc();
        }
    }

}
