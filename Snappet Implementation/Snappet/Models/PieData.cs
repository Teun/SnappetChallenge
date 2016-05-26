using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Models
{
    class PieData<T>
    {
        public List<T> series { get; set; }

        public PieData(List<T> series)
        {
            this.series = series;
        }
    }
}
