using Moserware.Skills.TrueSkill;
using SnappetTrueskill.Data;
using System;

namespace SnappetTrueskill
{
    public class NextBestExerciseRecommender
    {
        private readonly IUserRepository userRepository;
        private readonly IExerciseRepository exerciseRepository;

        private readonly TwoPlayerTrueSkillCalculator calculator;

        public NextBestExerciseRecommender(IUserRepository userRepository, IExerciseRepository exerciseRepository)
        {
            this.userRepository = userRepository;
            this.exerciseRepository = exerciseRepository;

            calculator = new TwoPlayerTrueSkillCalculator();
        }

        public int GetNextBestExercise(int userId)
        {
            throw new NotImplementedException();
        }

        public double CalculateExerciseQuality(int userId, int exerciseId)
        {
            throw new NotImplementedException();
        }
    }
}
