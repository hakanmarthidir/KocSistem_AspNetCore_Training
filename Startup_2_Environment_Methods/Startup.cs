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

namespace Startup_2_Environment_Methods
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Environmentları  If else ile yonetebileceginiz gibi ConfigureServices ve Configure methodlarına yapacagınız isim eklentileri ile de yonetebilirsiniz. 
        // Varsayılan proje baslangıc ortam adı Development dir. Set edilmis sekilde proje baslar. Ancak ortam adı set edilmedi ise varsayılanı Productiondır. 
        // Ortam ayarlarını daha rahat bir sekilde ayırabilirsiniz. 
        // ASPNETCORE_ENVIRONMENT degerine gore hangi methodu calistiracagını kendisi bulacaktır. 
        // ilgili proje uzerinde (Startup_2_Environment_Methods) sag click yapıp Properties diyerek Debug bolumune gelebilir ve ilgili degeri gorebilirsiniz. Su an Staging olarak ayarlanmıs durumdadır. 

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        public void ConfigureStaging(IApplicationBuilder app, IHostingEnvironment env)
        {              
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {            
            app.UseMvc();
        }
    }
}
