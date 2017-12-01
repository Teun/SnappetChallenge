using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    /// <summary>
    /// Students data file parser
    /// </summary>
    public interface IParser
    {
        IDictionary<int, IEnumerable<Record>> Parse(string path);
    }
}
