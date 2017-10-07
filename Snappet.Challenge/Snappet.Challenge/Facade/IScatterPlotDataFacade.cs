using Snappet.Challenge.Models;
using Snappet.Model;
using System.Collections.Generic;

namespace Snappet.Challenge.Facade
{
    public interface IScatterPlotDataFacade
    {
        IEnumerable<KeyValuePair<double, double>> GenerateScatterPlotData(IEnumerable<StudentSkill> skills, string subject);
    }
}