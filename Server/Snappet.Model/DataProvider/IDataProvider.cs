using System.Collections.Generic;
using Snappet.Model.Domain;

namespace Snappet.Model.DataProvider
{
    public interface IWorkDataProvider
    {
        IEnumerable<Work> GetWorkDetails();
    }
}
