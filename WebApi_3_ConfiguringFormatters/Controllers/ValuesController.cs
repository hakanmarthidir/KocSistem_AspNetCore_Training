using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_3_ConfiguringFormatters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // Content Negotiation yani Json mı Xml mi geri donus yapılacak muzakeresi uygulamaya gelen requestin Header basliginda gorunur. 
        //Eger requestin Accept Header parametresi varsa, framework yanıt uretebilecegi formatteri sıra ile aramaya baslar. accept header daki uygun formatter bulundugunda buna gore cevap dondurulur. 
        //Userın talep ettiği istege karsılık gelen herhangi bir formatter bulunamazsa framework yanıt verebilecegi ilk formatteri bulmaya calisir. bu durumları kısıtlamak için MvcOptions 406 Not Acceptable i configure etmemişse)

        // Xml olarak bilgi alınmak istediyse ve xml formatter sisteminizde yapılandırılmadı ise json formatında data biçimlendirilir 
        //İstek herhangi bir headera sahip degil ise/belirtilmemişse, dondurulecek nesnetyi handle edebilecek ilk formatter cevabı doner. bu durumda herhangi bir negotiation gerceklesmez buna sunucu karar verir ve hangi formatı kullanacagını belirler. 

        //Eger Accept headerı */* olarak belirtilmiş ise, RespectBrowserAcceptHeader parametresi true olarak ayarlanmadıkca headerı gormezden gelecektir. bu parameternin varsayılan degeri false tur. Bu degeri Startup.cs içerisindeki ConfigureServices içerisinde duzenleyebilirsiniz. projedeki ilgili methoda goz atın.. 

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}
