using Microsoft.EntityFrameworkCore;
using TeacherApp.Models;

namespace TeacherApp.Data
{
    public class TeacherAppDbContext : DbContext
    {
        public TeacherAppDbContext(DbContextOptions<TeacherAppDbContext> options)
        : base(options) { }

        public DbSet<Work> Works => Set<Work>();
        public DbSet<Student> Students => Set<Student>();
    }
}
