using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middlewares_4_WithClass_IMiddleware
{
    //1- MIDDLEWARE YAZILIR 
    // Gelen istekteki KocSistem headerinin valuesunu alır ve hazırlanmıs olan dbContexte kaydeder. 
    // Dbcontext veya buna benzer serviceleri constructor seviyesinde inject edebiliriz ve kullanabiliriz. 
    public class FactoryActivatedMiddleware : IMiddleware
    {
        private readonly MiddlewareDbContext dbcontext;

        public FactoryActivatedMiddleware(MiddlewareDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Headers["KocSistem"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                dbcontext.Add(new LogHeader() { HeaderValue = keyValue });
                dbcontext.SaveChanges();
            }       

            await next(context);
        }
    }

}
