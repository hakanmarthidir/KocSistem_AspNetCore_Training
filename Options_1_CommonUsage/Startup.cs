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

namespace Options_1_CommonUsage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        //Options pattern ; birbiri ile alakalı ayar/configuration kumelerimizi classları kullanarak yonetmeye calisan bir patterndir. 
        //Configurationların tamamı benzer senaryo kapsamında kullanılmaz, girmis oldugumuz ayarlar senaryo bazlı degiskenlik gosterebilir. 
        //bunlara ek olarak options patterni kullanmak istediginiz configuration datasını validate edebilen bir mekanizmaya da  sahiptir.         

        //1- Optionsları map edebilmek için kullanacagınız class abstract olamaz. MyOptions ve MySetting classını inceleyiniz.
        //2- Services bolumune register edilir. 
        //3- Kullanılmak istenen yerden cagrilir. (ValuesController gibi)


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Kullanım 1- > json dosyasındaki propertyleri direkt alma
            services.Configure<MyConfig>(Configuration);
            //Kullanım 2 -> json dosyasındaki belirli bir sectiona gore optionsları alma 
            services.Configure<MySetting>(Configuration.GetSection("SpecialSetting"));
            // Kullanım 3 -> configuration dosyasından classlara bilgileri aktarırken yapılan işleme mantıksal bir ad verebiliriz. daha sonra bu adı ilgili options nesnesni cagirirken kullanırız. 
            //bu mantıksal ada gore bind işlemini yapacaktır. 2 ornek olusturalim.           
            services.Configure<MyNamedConfig>("mynamed_options", Configuration);

            services.Configure<MyNamedConfig>("mynamed_options2", myoptions =>
            {
                myoptions.NamedFolder = "Empty Folder";
            });

            #region ConfigureAll

            //***** ConfigureAll
            //Buradaki kod blogu acılırsa NamedFolder kullanan tum mantıksal kumelere bu ayarı set etmiş oluyoruz. json dosyasında ne yazarsa yazsın ilgili property degerini buradan alır. 
            //Genel ayarların verildigi yerdir. 
            // Ornegin; Values Controller içerisinde mynamed_options, mynamed_options2 mantıksal adlarla yukleme yapıyoruz. Normal kosullarda jsondan bilgileri alıyorlar. 
            //Asagidaki kodlarla buradaki tum NamedFolderlar bir merkezden bilgiyi alır. 

            //services.ConfigureAll<MyNamedConfig>(myOptions =>
            //{
            //    myOptions.NamedFolder = "Burası Genel Ayar";
            //}); 
            #endregion

            #region PostConfiguration
            // ***** POST CONFIGURATION
            // bu kod tum IConfigure<Options> yapılandırılmasından sonra calisir. dataları manipule edebilirsiniz. 
            // app settingste 3.14 olarak belirlenmisti. 
            services.PostConfigure<MyConfig>(myOptions =>
            {
                myOptions.KsValue = 100;
            }); 
            #endregion
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }

        //**** Configure methodundan IOptionlara erişmek istenirse ; 
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsMonitor<MyConfig> config)
        //{
        //    //var application = config.CurrentValue.KsApplication;
        //    app.UseMvc();           
        //}

    }
}
