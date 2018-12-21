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

namespace Middlewares_2_Map_MapWhen
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

        #region Middleware Methods
        private static void Middleware1(IApplicationBuilder app)
        {
            app.Run(async context => { await context.Response.WriteAsync("Map Test 1"); });
        }

        private static void Middleware2(IApplicationBuilder app)
        {
            app.Run(async context => { await context.Response.WriteAsync("Map Test 2"); });
        }

        private static void MiddlewareMapWhen1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }

        private static void MiddlewarSubMapWhen1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var value = "nested map sample";
                await context.Response.WriteAsync(value);
            });
        }
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //MapWhen: genellikle bir kriter ile birlikte kullanılır. İLgili kosula uyuyorsa middlewarei cagirir. 
            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), MiddlewareMapWhen1);
            //Map ise gelen istege bakar ve eslesme soz konusu ise ilgili middleware e yollar. 
            app.Map("/map1", Middleware1);
            app.Map("/map2", Middleware2);
            //summap olarak adlandırılan ilk eslesme saglanıyor ise diger eslesmelere bakara map i kategorize etmemizi ve detaylandırmamızı saglar. 
            app.Map("/level1", level1App =>
            {
                level1App.Map("/level2a", level2AApp => { MiddlewarSubMapWhen1(level2AApp); });
                level1App.Map("/level2b", level2BApp => { MiddlewarSubMapWhen1(level2BApp); });
            });

            app.Run(async context => { await context.Response.WriteAsync("None"); });

            app.UseMvc();
        }
    }
}
