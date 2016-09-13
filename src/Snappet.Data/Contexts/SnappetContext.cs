using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Model;

namespace Snappet.Data.Contexts
{
    public class SnappetContext : DbContext
    {
        public SnappetContext(DbContextOptions<SnappetContext> options) 
            : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<LearningObjective> LearningObjectives { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
