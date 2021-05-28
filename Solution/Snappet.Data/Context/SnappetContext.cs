using Microsoft.EntityFrameworkCore;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Data.Context
{
    public class SnappetContext : DbContext
    {
        public SnappetContext(DbContextOptions<SnappetContext> options) : base(options)
        {

        }

        public DbSet<AnswerEntity> SubmittedAnswers { get; set; }
    }
}
