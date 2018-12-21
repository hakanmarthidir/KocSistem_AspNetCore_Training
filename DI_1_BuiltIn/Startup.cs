using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_1_BuiltIn.DependencySample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DI_1_BuiltIn
{
    public class Startup
    {

        //IConfiguration veya ILogger gibi nesneler varsayılan olarak onceden register edilmistir. 
        //bu nedenle register bolumunde bu tip nesneleri gormezsiniz. 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // Asp.Net Core Dependnecy Injection patternini destekler ve içerisinde built in container barındırır. 
            // Microsoft.Extensions.DependencyInjection paketini kullanır. Temel ihtiyaclar baz alınarak donatılmıs bir containerdir. 
            // Isterseniz .net core destekli baska containerlarda kullanabilirsiniz. bu konuda bir kısıtlama yok.             
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // 3 farklı lifetime vardır. 
            // Singleton -> ilk kez cagrildiklarında olusturulur ve bundan sonra hep aynı nesne referansını kullanır. 
            // Transient -> gecici omurlu. her istendiginde olusturulur. durumunu koruyamayan ve en hızlı sekilde calisan modeldir.
            // Scoped -> istek basına bir kez olusturulur. entity framework contextler genelde scoped dur. 

            //** DependencySample altında ornek bir interface ve class olusturuldu. 
            // İlgili nesne register edildi ve Controllers altındaki ValuesController içerisinde kullanıldı. 

            services.AddTransient<IStringServices, StringServices>();
            //services.AddScoped<IStringServices, StringServices>();
            //services.AddSingleton<IStringServices, StringServices>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
