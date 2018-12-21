using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares_3_WithClass
{
    public class MyHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public MyHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //BEFORE
            context.Response.Headers.Add("KocSistemHeader", "1234");
            await _next(context);
            //AFTER
        }
    }

}
