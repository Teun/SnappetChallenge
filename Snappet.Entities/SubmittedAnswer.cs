using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Entities.Interfaces;

namespace Snappet.Entities
{
	public class SubmittedAnswer : ISubmittedAnswer
	{
		public SubmittedAnswer(int id, DateTime submittedDateTime, bool correct, double progress, string user, string exercise, string learningObjective, string subject, string domain)
		{
			Id = id;
			SubmittedDateTime = submittedDateTime;
			Correct = correct;
			Progress = progress;
			User = user;
			Exercise = exercise;
			LearningObjective = learningObjective;
			Subject = subject;
			Domain = domain;
		}

		public int Id { get; }

		public DateTime SubmittedDateTime { get; }

		public bool Correct { get; }

		public double Progress { get; }

		public string User { get; }

		public string Exercise { get; }

		public string LearningObjective { get; }

		public string Subject { get; }

		public string Domain { get; }
	}
}
