using Microsoft.EntityFrameworkCore;

namespace Middlewares_4_WithClass_IMiddleware
{
    //EF Core da olusturulmus bir inmemory dbcontext. 
    public class MiddlewareDbContext : DbContext
    {
        public DbSet<LogHeader> Headers { get; set; }

        public MiddlewareDbContext(DbContextOptions<MiddlewareDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("headerlog");
        }        
    }

}
