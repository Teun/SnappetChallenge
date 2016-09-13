using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Data.Loader.Model
{
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

    //"SubmittedAnswerId":2396696,
    //"SubmitDateTime":"2015-03-02T07:36:59.653",
    //"Correct":1,
    //"Progress":2,
    //"UserId":40281,
    //"ExerciseId":1029121,
    //"Difficulty":"353.3972855",
    //"Subject":"Begrijpend Lezen",
    //"Domain":"-",
    //"LearningObjective":"Diverse leerdoelen Begrijpend Lezen"
}
