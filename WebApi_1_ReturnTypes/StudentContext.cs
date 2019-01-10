using Microsoft.EntityFrameworkCore;

namespace WebApi_1_ReturnTypes
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=School;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student() { StudentId = 1, StudentName = "Jordan" },
                new Student() { StudentId = 2, StudentName = "Kobe" },
                new Student() { StudentId = 3, StudentName = "Carter" });
        }
    }
}
