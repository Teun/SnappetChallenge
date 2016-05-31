using Snappet.Entities.Interfaces;

namespace Snappet.Services.Interfaces
{
	public interface IProgressByStudent
	{
		string LearningObjective { get; }

		double Progress { get; }

		void AddProgress(double progressToAdd);
	}
}