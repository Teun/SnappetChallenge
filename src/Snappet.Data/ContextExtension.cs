using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Configuration;
using Snappet.Data.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Data
{
    public static class ContextExtension
    {
        public static void AddContexts(this IServiceCollection services)
        {
            string pathToDB = Path.Combine(Config.ApplicationBasePath, "Snappet.Data", "snappet.db");

            if(File.Exists(pathToDB))
            {
                services.AddDbContext<SnappetContext>(options => options.UseSqlite("Filename=" + pathToDB));
            }
            else
            {
                throw new FileNotFoundException($"Cannot load .db from: {pathToDB}. Context instantiation terminated.");
            }
        }
    }
}
