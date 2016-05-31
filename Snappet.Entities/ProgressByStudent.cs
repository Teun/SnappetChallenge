using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Entities.Interfaces;
using Snappet.Services.Interfaces;

namespace Snappet.Entities
{
	public class ProgressByStudent : IProgressByStudent
	{
		public ProgressByStudent(string learningObjective, double progress)
		{
			LearningObjective = learningObjective;
			Progress = progress;
		}

		public string LearningObjective { get; }

		public double Progress { get; private set; }

		public void AddProgress(double progressToAdd)
		{
			Progress += progressToAdd;
		}
	}
}
