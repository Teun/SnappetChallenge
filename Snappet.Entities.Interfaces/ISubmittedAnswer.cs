using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Entities.Interfaces
{
    public interface ISubmittedAnswer
    {
		int Id { get; }

		DateTime SubmittedDateTime { get; }

		bool Correct { get; }

		double Progress { get; }

		string User { get; }

		string Exercise { get; }

		string LearningObjective { get; }

		string Subject { get; }

		string Domain { get; }
    }
}
