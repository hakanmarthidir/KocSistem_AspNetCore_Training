using Microsoft.AspNetCore.Builder;

namespace Middlewares_3_WithClass
{
    public static class MyHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseKocSistemHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHeaderMiddleware>();
        }
    }

}
