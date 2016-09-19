using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Model.DTO
{
    public class ProgressPerUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public double AverageProgress { get; set; }
    }
}
