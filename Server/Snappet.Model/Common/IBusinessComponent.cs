using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Model.Common
{
    public interface IBusinessComponent
    {
        T GetBusinessComponent<T>();
        T GetBusinessComponent<T>(string aliasName);
        T GetRepository<T>();
        T GetRepository<T>(string aliasName);
    }
}
