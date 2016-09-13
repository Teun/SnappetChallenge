using Snappet.Model.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Model
{
    public class LearningObjective : IBasicContext
    {
        [Key]
        public int ID { get; set; }

        public string Objective { get; set; }
    }
}
