using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Data.Contexts.Factories
{
    public class SnappetContextFactory : IDbContextFactory<SnappetContext>
    {
        public SnappetContext Create(DbContextFactoryOptions options)
        {
            string pathToDB = Path.Combine(options.ContentRootPath, "snappet.db");
            DbContextOptionsBuilder<SnappetContext> optionsBuilder = new DbContextOptionsBuilder<SnappetContext>();
            optionsBuilder.UseSqlite("Filename=" + pathToDB);

            return new SnappetContext(optionsBuilder.Options);
        }
    }
}
