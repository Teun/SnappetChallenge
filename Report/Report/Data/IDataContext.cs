using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Data
{
    public interface IDataContext
    {
        Task<IEnumerable<UserActivity>> Get();
    }
}
