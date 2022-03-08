using ClassRegister.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Persons> Person { get; set; }
        public DbSet<Accounts> Account { get; set; }
        public DbSet<Courses> Course { get; set; }
        public DbSet<Enrollments> Enrollment { get; set; }
        public DbSet<Grades> Grade { get; set; }
        public DbSet<Subjects> Subject { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}