using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_2_FormatResponseData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        //Action Result Typelar belirli bir formatta olabilir. JsonResult veya ContentResult gibi. 
        //JsonResult json olarak formatlanmıs datayı doner, 
        //ContentResult ise plain-text formatlı string data doner. 

        //actionlar özel bir geri donus tipine ihtiyac duymazlar, MVC herhangi bir donus tipini zaten destekliyor. Normal bir senaryoda eger actionınız IActionResult donuyorsa ve Controlleriniz Controller nesnesinden kalıtım alıyorsa elimizde bir cok secenek var demektir. Varsayılan olarak ControllerBase den kalıtım alıyor Controllerlarımız buraya dikkat etmek gerekiyor. 

        //** eger IActionResult tabanlı bir returnumuz yoksa IOutputFormatter kullanılarak serialize edilir ve geri donus saglanır. 

        //** ASP.NET Core MVC için default format JSONdir. 
        //eger siz istegi yollarken Accept : applicatio/xml seklinde bilgi almak isteniz bile eger ozel olarak tanımlı bir formatter yok ise cevap size yine Json gelecektir. 

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ContentResult Get(int id)
        {
            return Content("value");
        }

        // ContentResult lu kullanım yerine asagidaki kullanımı da olusturabilirsiniz aynı seydir.         
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

    }
}
