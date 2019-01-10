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
    public class IActionResultController : ControllerBase
    {

        // 2- IActionResult Type
        // Belirli bir action içerisinde birden fazla ActionResult tipi donmeniz gerekirse kullanabileceginiz bir yontemdir. 
        // Specific Type da bahsedildigi gibi karsılasılan duruma gore BadRequest, NotFound, Ok Resultları donebiliriz. Bunu yaparken kullanılabilecek bir attribute ile potansiyel geri donus tiplerini sisteme tanıtmıs oluruz. 
        // api action ımızı daha acıklayıcı bir duruma gtirebilir ve Swagger tarzı api dokumantasyonu için kullanılacak toollara destek verebiliriz. 

        private readonly StudentContext context;
        public IActionResultController(StudentContext context)
        {
            this.context = context;
        }

        // SENKRON ORNEK
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            if (context.Students.Count() == 0)
            {
                return NotFound();
            }

            return Ok(context.Students.ToList());
        }

        //ASENKRON ORNEK
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            if (student == null)
            {
                return BadRequest(ModelState);
            }

            await context.Students.AddAsync(student);
            return Ok();
        }

        //Ek bilgi : Asagidaki gibi bir ornekte status durumlarına gore farklı sonuclar donduruluyor. 
        //Badrequestte id bilgisi donulurken, Ok statusunde nesnenin kendisi donuyor. 
        //bu durumda IActionResult geri donus degerlerini ObjectResult a wrap eder. 
        //[HttpGet]        
        //public IActionResult GetById(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest(id);
        //    }

        //    return Ok(context.Students.Where(x=>x.StudentId == id).FirstOrDefault());
        //}



    }    
}