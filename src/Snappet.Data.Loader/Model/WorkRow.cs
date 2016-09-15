using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Data.Loader.Model
{
    /// <summary>
    /// Used to map json to class.
    /// </summary>
    public class WorkRow
    {
        public int SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public double Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
