using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snappet.WebAPI.Models
{
    public class Student
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Exercises { get; set; }
        public int Attempts { get; set; }
        public string Performance { get; set; }        
    }
}
