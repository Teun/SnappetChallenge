using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Models;

namespace SchoolMaster.Database
{
    public class WorkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> UserWorks { get; set; }

        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }
    }
}
