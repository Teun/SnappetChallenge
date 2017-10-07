using Snappet.Model;
using System.Collections.Generic;

namespace Snappet.Data
{
    public interface IDataFactory
    {
        IList<StudentSkill> FetchData();
    }
}
