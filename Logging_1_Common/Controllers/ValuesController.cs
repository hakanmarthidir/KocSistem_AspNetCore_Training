using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging_1_Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }
     
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {            
            this.logger.LogCritical("CRITIC SAMPLE");
            return new string[] { "value1", "value2" };
        }
    }
}
