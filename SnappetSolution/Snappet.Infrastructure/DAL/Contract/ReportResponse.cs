using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Contract
{
	public class ReportResponse
	{
		//Dimensions
		public int? Correct { get; set; }
		public int? UserId { get; set; }
		public int? ExerciseId { get; set; }
		public string Subject { get; set; }
		public string Domain { get; set; }
		public string LearningObjective { get; set; }

		//Measures
		public decimal? DifficultyAvg { get; set; }
		public int? ProgressSum { get; set; }
		public int ExcercisesTotal { get; set; }
		public decimal CorrectRate { get; set; }
	}
}
