using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_4_AddingFormatters.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Hic bir Header bilgisi girmeden Get isteginde bulunursak alacagımız sonuc Json olacaktır
        //Response Json

        //{ "name": "Hakan", "surname": "Hidir" }

        //İlgili Requestin Header bilgisine application/xml yazarsak ;
        //Response Xml

        //<XmlSample xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        //<Name>Hakan</Name>
        //<Surname>Hidir</Surname>
        //</XmlSample>


        // GET api/values
        [HttpGet]
        //[Produces("application/json")]
        public ActionResult<XmlSample> Get()
        {
            return new XmlSample() { Name = "Hakan", Surname = "Hidir" };
        }

        //Produces Attribute
        // Bir actionu veya controllerı belirlenen bir formatta almak için zorlayabilirsiniz. 
        // [Produces("application/json")] attributeunu kullanarak application/xml headerı ile bile istekte bulunsanız cevabı json alırsınız.             

    }


    public class XmlSample
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
