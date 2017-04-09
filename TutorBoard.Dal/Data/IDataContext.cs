using System.Collections.Generic;
using TutorBoard.Dal.Dtos;

namespace TutorBoard.Dal.Data
{
    public interface IDataContext
    {
        IEnumerable<WorkDto> GetWorkData();
    }
}
