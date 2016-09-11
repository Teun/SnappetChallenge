using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;
using Snappet.Repository.Implementation;
using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddContexts();

            services.AddSingleton<IAnswerRepository, AnswerRepository>();
        }
    }
}
