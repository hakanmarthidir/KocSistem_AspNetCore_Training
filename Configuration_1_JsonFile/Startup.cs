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

namespace Configuration_1_JsonFile
{
    public class Startup
    {
        //Uygulamanıza yön verecek, sekillendirecek dataları key-value seklinde sizlere sunan bir saglayıcıdır. 
        //Uygulamayı ilgilendiren ayarları cok farklı kaynaklarda tutabilirsiniz. 
        // Bu datalar InMemory, Azure Key Vault, Json, Ini, Xml, Environment Variables gibi alanlarda durabilir. 
        //Buradaki bilgilerin duzenli bir sekilde sunulması için Microsoft Extension Configurationdan yararlanabiliriz. 

        // Bu patternin bir uzantısıda IOptions yapısıdır. Bu yapı ile birlikte alakalı configuration datalarını classları kullanarak elde edebilirsiniz. 
        // appsettings.json dosyası içerisine bir takım datalar ekliyoruz. 

        // Program.cs içerisinde Configuration ayarlarını yapılandıralım. 
        // ValuesController içerisinden Json dosyası içerisindeki datalara erişelim. 


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


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
