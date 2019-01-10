using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_1_ReturnTypes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionResultController : ControllerBase
    {
        private readonly StudentContext context;
        public ActionResultController(StudentContext context)
        {
            this.context = context;
        }

        //ASP.NET Core 2.* Web API controller actionları için bir de ActionResult<T> u kullandırmaktadir. 

        //Bu kullanım ile birlikte;
        // ProducesResponseType attributeundaki Type kısmına gerek kalmamıstır. Type kısmı generic yapıdaki T den beslenecektir. 
        // Sadece soyle demek yeterlidir. [ProducesResponseType(200)]

        // T nesnesini ve ActionResult nesnesini ActionResult<T> ye cast edebilir.
        //Ornegin asagidaki ornekte oldugu gibi geri donus tipi ActionResult olmasına ragmen kod içerisinde sadece List i donebiliriz.

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return context.Students;
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Student> GetByIndex([FromQuery]int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var firstStudent = context.Students.FirstOrDefault(z => z.StudentId == id);
            return firstStudent;
            //veya
            //return Ok(firstStudent);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            await context.Students.AddAsync(student);
            return Ok();
        }



    }
}