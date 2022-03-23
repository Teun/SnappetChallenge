using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Models
{
    public class StudentExerciseDetailsModel
    {
        public IEnumerable<ExerciseModel>? Exercises { get; set; }
    }
}
