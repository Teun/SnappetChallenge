using Snappet.Challenge.Models;
using Snappet.Model;
using System.Collections.Generic;

namespace Snappet.Challenge.Facade
{
    public interface IStatisticsDataFacade
    {
        DataPoint GenerateBellCurveData(IEnumerable<StudentSkill> skills,string subject);
    }
}
