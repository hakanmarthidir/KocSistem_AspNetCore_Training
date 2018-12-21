using Microsoft.EntityFrameworkCore;

namespace EfCore_1_Introduction
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
                new Student() { StudentId = 1, StudentName = "Hakan" },
                new Student() { StudentId = 2, StudentName = "Ahmet" },
                new Student() { StudentId = 3, StudentName = "Mehmet" });
        }
    }
}
