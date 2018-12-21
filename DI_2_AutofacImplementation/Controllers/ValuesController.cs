using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_2_AutofacImplementation.DependencySample;
using Microsoft.AspNetCore.Mvc;

namespace DI_2_AutofacImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IStringServices stringService;

        public ValuesController(IStringServices stringService)
        {
            this.stringService = stringService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var textPrefix = this.stringService.SetPrefix("aspnetcore", "microsoft");
            return textPrefix;
        }
    }
}
