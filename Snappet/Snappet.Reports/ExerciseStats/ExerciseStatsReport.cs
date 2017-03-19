using Snappet.Data.Entities;
using Snappet.Data.Interfaces;
using System.Reflection;

namespace Snappet.Reports.ExerciseStats
{
    [Obfuscation(Exclude = true, ApplyToMembers = false)]
    public class ExerciseStatsReport : Report<ExerciseStatsParameters>
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseStatsReport(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        protected override object Generate(ExerciseStatsParameters parameters)
        {
            // could switch between aggregate level based on parameters, now simply aggregate by Subject
            var model = new ExerciseStatsModel<ExerciseStatsBySubject>
            {
                Parameters = parameters,
                Title = "Overzicht opgaven per onderwerp", // should be resource name and translated in view
                ExerciseStats = _exerciseRepository.Get<ExerciseStatsBySubject>().From(parameters.UtcFrom).To(parameters.UtcTo).ToList()
            };
            return model;
        }
    }
}