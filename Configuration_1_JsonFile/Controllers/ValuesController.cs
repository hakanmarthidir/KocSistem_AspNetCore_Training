using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Configuration_1_JsonFile.Controllers
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

            StringBuilder sb = new StringBuilder();
            //Json içerisindeki Hakan isimli alanın alt nesnelerini aldık. 
            //ApplicationName ve Department keyleri valueleri ile birlikte gelecektir. 
            var myConfig = this.configuration.GetSection("Hakan").GetChildren();
            //Her bir bilgiyi teker teker işleyelim.
            foreach (var item in myConfig)
            {                
                //Valuelar her zaman stringtir. 
                sb.Append(item.Value);
                sb.Append("_");
            }
            return sb.ToString();
        }

        //[HttpGet]
        //public ActionResult<string> Get()
        //{
        //    // sadece belirli bir alandaki key in value sunu almak istersek : den yararlanırız. 
        //    var myConfig = this.configuration.GetSection("Hakan:ApplicationName");
        //    return myConfig.Value;
        //}


    }
}
