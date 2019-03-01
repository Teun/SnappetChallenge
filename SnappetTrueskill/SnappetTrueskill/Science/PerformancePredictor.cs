using Moserware.Skills;
using SnappetTrueskill.Data;
using System;

namespace SnappetTrueskill.Science
{
    public class PerformancePredictor
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseInteractionRepository _exerciseInteractionRepository;

        private readonly GameInfo _gameInfo;

        public PerformancePredictor(IUserRepository userRepository, IExerciseRepository exerciseRepository, IExerciseInteractionRepository exerciseInteractionRepository, GameInfo gameInfo)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseInteractionRepository = exerciseInteractionRepository;

            _gameInfo = gameInfo;
        }

        public double GetAccuracyOnTestSet(DateTime startTime)
        {
            throw new NotImplementedException();
        }
    }
}
