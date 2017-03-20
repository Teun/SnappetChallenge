using Services.Entities;
using System;
using System.Collections.Generic;

namespace Services.Repositories
{
    public interface IWorkRepository
    {
        IReadOnlyCollection<Work> GetAllWork();

        IReadOnlyCollection<Work> GetCurrentWork(DateTime timestamp);
    }
}
