using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    /// <summary>
    /// Application configurations
    /// </summary>
    public interface IAppConfig
    {
        string DataFilePath { get; }
    }
}
