using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Services.Contracts
{
    public interface ISubjectService
    {
        Dictionary<string, float> GetTimeSpentInPercentagesBySubject(DateTime from, DateTime until);
    }
}
