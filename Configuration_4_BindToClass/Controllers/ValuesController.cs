using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Configuration_4_BindToClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            //Method 1
            //appsettings.json içerisinde tanımlı belirli bir setting grubuna gore MyConfig classı yazıldı. 
            //Classın propertyleri bind edilecek sekilde conf dosyasındaki adlara gore verildi. 
            //Bind methodu kullanılarak ilgili section class ile ortusturuldu ve kullanıma hazırlandı. 

            MyConfig config = new MyConfig();
            this.configuration.GetSection("MyConfig").Bind(config);
            return config.ApplicationName;

            //Method 2 
            //Bind methodu ile yapılabildigi gibi Get methodu ile de yapılabilir. 
            //MyConfig config = this.configuration.GetSection("MyConfig").Get<MyConfig>();
            //return config.ApplicationName;

        }
    }
}
