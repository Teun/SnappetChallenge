using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository
{
    public static class ContextExtension
    {
        public static void AddContexts(this IServiceCollection services)
        {
            services.AddDbContext<AnswerContext>(options => options.UseSqlite("Filename=./answer.db"));
        }
    }
}
