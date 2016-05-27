using System.Collections.Generic;

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
