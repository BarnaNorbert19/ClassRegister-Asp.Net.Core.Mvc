using ClassRegister.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Subject> Subject { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}