using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_4_AddingFormatters.Controllers
{
    [FormatFilter]    
    [ApiController]
    public class FormatFilterController : ControllerBase
    {
        [Route("[controller]/[action]/{id}.{format?}")]
        public string Get(int id)
        {
            return "Hakan";
        }

        //FormatFilter Attribute
        // Yukarıdaki ornekte client istedigi cevabı belirli bir url yolu ile alabilir. 
        // Ornegin; formatfilter/Get/5 dediginde cevap alabilecegi gibi, 
        //formatfilter/Get/5.json dediginde json formatında,
        //formatfilter/Get/5.xml dediginde xml formatında response alabilir. 

        //File uzantısına gore cevabı almak için formatfilter attributeunu kullanabiliriz. uzantıyı kontrol eder, ilgili formateri bulmaya calisir ve cevabı doner. 
        // formatfilter/Get/5 orneginde herhangi bir uzantı olmadıgı için varsayılan output formater ne ise onunla doner. 


    }
}