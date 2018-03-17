using System.Collections.Generic;

namespace Ngx.Charts
{
    public class Multiple
    {
        public string Name { get; set; }
        public IEnumerable<Single> Series { get; set; }
    }
}
