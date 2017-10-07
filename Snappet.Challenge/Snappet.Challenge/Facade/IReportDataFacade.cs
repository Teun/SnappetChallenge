using Snappet.Model;
using System.Collections.Generic;

namespace Snappet.Challenge.Facade
{
    public interface IReportDataFacade
    {
        IEnumerable<UserDto> ProcessSkillsData(IEnumerable<StudentSkill> skills);
    }
}