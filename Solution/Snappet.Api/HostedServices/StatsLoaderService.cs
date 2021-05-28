using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappet.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snappet.Api.HostedServices
{
    public class StatsLoaderService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public StatsLoaderService(IServiceProvider services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {                
                using(var scope = _services.CreateScope())
                {
                    var statsProcessingService = scope.ServiceProvider.GetRequiredService<IStatsProcessingService>();

                    await statsProcessingService.ProcessStats();
                    await Task.Delay(TimeSpan.FromMinutes(10));
                }
            }
        }

       
    }
}
