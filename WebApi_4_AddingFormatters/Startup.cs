using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApi_4_AddingFormatters
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
            //1- Xml formatting eklemek istiyorsanız oncelikle Microsoft.AspNetCore.Mvc.Formatters.Xml nuget paketini yuklemelisiniz. 
            //2- Artık asagidaki gibi AddXmlSerializerFormatters methodunu ekleyebilir ve Mvc configure edebilirsiniz. 

            //Yontem 1 
            services.AddMvc().AddXmlSerializerFormatters();

            //Yontem 2
            //services.AddMvc(options =>
            //{
            //    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            //});

            // Yukarıdaki her iki yontem de serialize islemi için System.Xml.Serialization.XmlSerializer i kullanır. Eger System.Runtime.Serialization.DataContractSerializer ı kullanmak isterseniz yapmanız gereken ilgili formatteri asagidaki gibi eklemektir. 

            //services.AddMvc(options =>
            //{
            //    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            //});
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {           
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
