using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Options_1_CommonUsage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly MyConfig options;
        private readonly MySetting setting;
        private readonly MyNamedConfig namedoptions;
        private readonly MyNamedConfig namedoptions2;

        // Microsoft.Extensions.Options paketi bu işlemleri yapabilmek için ihtiyac duydugumuz seydir. 

        // *IOptionsFactory : yeni option örnekleri olusturmakla yukumludur

        // *IOptionsMonitorCache : IOptionsMonitor tarafından option nesnelerinin cachelenmesi için kullanılır. 

        // *IOptionsSnapshot : eger optionlar her istekte (requestte) yeniden hesaplanması gereken senaryolara sahipse o zaman kullanılır. 
        //  baska bir deyisle configuration datalarının reload edilebilmeleri için kullanılır. Bu sekilde calismasını istiyorsak IOptionsMonitor yerine IOptionsSnapshot yazabiliriz. 

        // *IOptions, IOptionsMonitor: genel kullanımda IOptionsMonitor ile configuration datalarını alabilirsiniz. 


        public ValuesController(IOptionsMonitor<MyConfig> options, IOptionsMonitor<MySetting> setting, IOptionsMonitor<MyNamedConfig> namedoptions)
        {
            this.options = options.CurrentValue;
            this.setting = setting.CurrentValue;
            this.namedoptions = namedoptions.Get("mynamed_options");
            this.namedoptions2 = namedoptions.Get("mynamed_options2");
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {
                options.KsApplication,
                options.KsValue.ToString(),
                setting.AppFolder,
                namedoptions.NamedFolder,
                namedoptions2.NamedFolder };
        }
    }
}
