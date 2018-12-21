using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Startup_1_Default
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Kullanılacak servicelerin register edildigi bir baslangıc methodudur. 
        // AddIdentity, AddDbContext, AddMvc ve benzeri bir cok service bu sekilde eklenebilir. 
        //Aynı zamanda builtin dependency injection containerina register işlemleri de burada yapılır. 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // Http Request Pipelineini yönetmek ve configure etmek için kullanılan methoddur. 
        // builtin middlewareler eklenebilecegi gibi kendi yazmıs oldugumuz middlewarelerin belirtilen sıra cagrilmasi burada saglanır. 
        // Sıralama onemlidir. 
        // Exception page, browserlink, static files, mvc ve daha bir cok middleware bulunmaktadır. 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //IHostingEnvironment uygulamanın calistigi environmenta gore davranıs modellerimizi belirlyebiliriz. 
            //Production, Staging, Development gibi onceden tanımlı environmentlar vardır. her ortamın farklı kosulları olabilir. 

            //Environment name propertysi ile  ASPNETCORE_ENVIRONMENT e atanmıs degeri ogrenebilirsiniz.
            var name = env.EnvironmentName;

            // Ortamlara gore farklı configurationlar yapmak mumkundur. 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                app.UseHsts();
            }
            else if (env.IsEnvironment("MyCustomEnvironment"))
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            else
            {
                app.UseHttpsRedirection();
            }          

            app.UseMvc();
        }
    }
}
