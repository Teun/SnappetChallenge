using SnappetDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetDomain.Repositories
{
    public interface ISnappetRepository
    {
        IEnumerable<LearningSubject> GetLearningDataByDate(DateTime maxDateTime);
    }
}
