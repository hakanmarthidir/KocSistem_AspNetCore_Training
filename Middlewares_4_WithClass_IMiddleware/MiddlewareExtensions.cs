using Microsoft.AspNetCore.Builder;

namespace Middlewares_4_WithClass_IMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FactoryActivatedMiddleware>();
        }
    }

}
