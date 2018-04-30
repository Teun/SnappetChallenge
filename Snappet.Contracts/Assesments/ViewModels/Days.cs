using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DaysAttribute : Attribute
    {
        public int Number { get; set; }
    }
}
