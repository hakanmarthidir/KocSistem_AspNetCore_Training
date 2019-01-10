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

namespace WebApi_3_ConfiguringFormatters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        

        //Gunumuzde sıklıkla kullanılan API istemcilerinden farklı olarak, web browserlar (IE,Chrome vs.) çeşitli Accept headerlarına destek verebilmektedir. 
        //Postman gibi bir uygulamaya bakarsanız bunları gormek pek mumkun olmuyor, browserlar */* gibi cesitli wildcardlar kullanarak istekte bulunabilirler. 
        //Asagidaki false olarak işaretlenmiş options ayarı ile aslında su soylenmek isteniyor. eger framework requestin browser üzerinden geldiğini anlarsa, kullanılan Accept headerını yok sayar ve bunun yerine varsayılan formatter ile cevaplandırır. biliyorsunuz ki aksi belirtilmedikce bu Json dir. 


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options => { options.RespectBrowserAcceptHeader = true; } // varsayılan olarak false.                 
                );
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
