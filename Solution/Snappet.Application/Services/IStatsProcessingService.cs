using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snappet.Application.Services
{
    public interface IStatsProcessingService
    {
        Task ProcessStats();
    }
}
