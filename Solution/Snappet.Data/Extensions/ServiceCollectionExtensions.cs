using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IAnswersDataProvider, AnswersDataProvider>();
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddDbContext<SnappetContext>(options => options.UseInMemoryDatabase(databaseName: "Snappet"));
        }
    }
}
