using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Middlewares_4_WithClass_IMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {     
       
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {          
            return new string[] { "value1", "value2" };
        }       
    }
}
