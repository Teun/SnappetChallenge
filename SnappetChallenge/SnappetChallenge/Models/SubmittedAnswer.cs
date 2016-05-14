using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
	public class SubmittedAnswer
	{
		public long SubmittedAnswerId { get; set; }
		public DateTime SubmittedDateTime { get; set; }
		public DateTime SubmittedDate { get { return SubmittedDateTime.Date;  } } 
		public bool Correct { get; set; }
		public int Progress { get; set; } 
		public long UserId { get; set; }
		public long ExerciseId { get; set; }
		public double Difficulty { get; set; }
		public string Subject { get; set; }
		public string Domain { get; set; }
		public string LearningObjective { get; set; }
	}
}