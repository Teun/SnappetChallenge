using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    /// <summary>
    /// Used by the parser
    /// </summary>
    public class Record
    {
        public int SubmittedAnswerId { get; set; }      //2395278
        public DateTime SubmitDateTime { get; set; }    //2015-03-02T07:35:38.740,
        public bool Correct { get; set; }               //1,
        public int Progress { get; set; }               //0,
        public int UserId { get; set; }                 //40281,
        public int ExerciseId { get; set; }             //1038396,
        public decimal Difficulty { get; set; }             //-200,
        public string Subject { get; set; }             //"Begrijpend Lezen",
        public string Domain { get; set; }              //"-",
        public string LearningObjective { get; set; }   //"Diverse leerdoelen Begrijpend Lezen"
    }
}
