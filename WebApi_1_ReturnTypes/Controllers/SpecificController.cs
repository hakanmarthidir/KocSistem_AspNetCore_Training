using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_1_ReturnTypes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificController : ControllerBase
    {
        // 1- Specific Type 
        // ilkel ve karmasık veri tiplerinin donduruldugu yontemdir. 
        // bu tip bir uygulamada sadece belirtilen tipte geri donus saglanacaktır. Bazen kosullara bagli olarak farkli veri tiplerinde donusler saglanabilir. 
        // Ornegin OkResult, BadRequestResult yada NotFoundResult gibi. bu gibi durumları dusununce uygulanısı ile sıklıkla karsılasmıyoruz. 

        private readonly StudentContext context;
        public SpecificController(StudentContext context)
        {
            this.context = context;
        }

        //SENKRON ORNEK - spesifik bir type donerken eger data null ise framework 204 No Content cevabını verecektir. 
        [HttpGet]
        public List<Student> Get()
        {          
            return context.Students.ToList();
        }

        //ASENKRON ORNEK
        [HttpGet]
        public async Task<int> GetCount()
        {
            return context.Students.Count();
        }

    }
}