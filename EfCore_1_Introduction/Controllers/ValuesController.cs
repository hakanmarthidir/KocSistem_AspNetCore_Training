using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore_1_Introduction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StudentContext context;
        public ValuesController(StudentContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var list = context.Students.AsNoTracking().Select(x => x.StudentName).ToList();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var studentName = context.Students.AsNoTracking().FirstOrDefault(x => x.StudentId == id).StudentName;
            return studentName;   
        }

        // POST api/values
        [HttpPost]
        public async Task PostAsync([FromBody] StudentInsertDto model)
        {
            var student = new Student() { StudentName = model.name };
            context.Students.Add(student);
            await context.SaveChangesAsync();
        }       

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Students.Remove(context.Students.Find(id));
            context.SaveChanges();
        }
    }
}
