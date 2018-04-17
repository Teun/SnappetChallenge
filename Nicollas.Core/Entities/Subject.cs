using System;
using System.Collections.Generic;
using System.Text;

namespace Nicollas.Core.Entities
{
    public class Subject: BaseEntity<int>
    {
        public string Description { get; set; }
    }
}
