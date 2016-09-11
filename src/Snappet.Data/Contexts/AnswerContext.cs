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
    public class AnswerContext : DbContext
    {
        public AnswerContext(DbContextOptions<AnswerContext> options) 
            : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }
    }
}
