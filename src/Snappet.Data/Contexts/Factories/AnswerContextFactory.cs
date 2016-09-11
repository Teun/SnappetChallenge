using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Data.Contexts.Factories
{
    public class AnswerContextFactory : IDbContextFactory<AnswerContext>
    {
        public AnswerContext Create(DbContextFactoryOptions options)
        {
            string pathToDB = Path.Combine(options.ContentRootPath, "answer.db");
            DbContextOptionsBuilder<AnswerContext> optionsBuilder = new DbContextOptionsBuilder<AnswerContext>();
            optionsBuilder.UseSqlite("Filename=" + pathToDB);

            return new AnswerContext(optionsBuilder.Options);
        }
    }
}
