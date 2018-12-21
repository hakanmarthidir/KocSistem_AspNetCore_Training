using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Configuration_2_InMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            //GetValue methodu kullanılarak Configuration içerisindeki bir bilgi alınabilir. 
            var myConfig = this.configuration.GetValue<string>("Department");
            return myConfig;
        }
    }
}
