using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Startup_3_Environment_Classes
{
    public class StartupProduction
    {
        public StartupProduction(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // Daha onceki ornekte environmentlara gore configure ve configureservices methodlarını isimlendirmistik. 
        // cok fazla ayarın olabildigi durumlarda bu methodlar karmasa yaratabilir. bu nedenle benzer bir isimlendirme ile starup classlarını tamamen ayrıstırabiliriz. 
        //** Program.cs deki kod degisikligine dikkat edin. 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
