using Moserware.Skills;
using SnappetTrueskill.Data;
using SnappetTrueskill.Domain;
using System;

namespace SnappetTrueskill.Science
{
    public class PerformancePredictor
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseInteractionRepository _exerciseInteractionRepository;
        private readonly ITrueskillEventRepository _eventRepository;

        private readonly GameInfo _gameInfo;

        public PerformancePredictor(IUserRepository userRepository, IExerciseRepository exerciseRepository, IExerciseInteractionRepository exerciseInteractionRepository, ITrueskillEventRepository eventRepository, GameInfo gameInfo)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseInteractionRepository = exerciseInteractionRepository;
            _eventRepository = eventRepository;

            _gameInfo = gameInfo;
        }

        /// <summary>
        /// Predict win probability on the test set.
        /// </summary>
        /// <param name="startDate"></param>
        public void PredictOnTestSet(DateTime startDate)
        {
            foreach (var interaction in _exerciseInteractionRepository.GetAll())
            {
                // Do not include this record if date is before `startDate`
                if (interaction.SubmitDateTime < startDate)
                    continue;

                // Check if user and exercise are known in database
                if (!_userRepository.Contains(interaction.UserId) || !_exerciseRepository.Contains(interaction.ExerciseId))
                    continue;

                var currentUserRating = _userRepository.Get(interaction.UserId).Ratings[interaction.Subject];
                var currentExerciseRating = _exerciseRepository.Get(interaction.ExerciseId).Rating;

                var user = new Player(interaction.UserId);
                var exercise = new Player(interaction.ExerciseId);

                var team1 = new Team(user, currentUserRating);
                var team2 = new Team(exercise, currentExerciseRating);

                var teams = Teams.Concat(team1, team2);

                // Estimate match quality and probability of correctness
                var quality = TrueSkillCalculator.CalculateMatchQuality(_gameInfo, teams);
                var winProbability = WinProbability(currentUserRating, currentExerciseRating);

                // Write prediction to repo
                var predObject = new TrueskillEvent { ExerciseInteraction = interaction, Quality = quality, CorrectProbability = winProbability, ExerciseRating = currentExerciseRating.Mean };
                _eventRepository.Add(predObject);
            }

            _eventRepository.Save();
        }

        /// <summary>
        /// Calculates win probability of a 1v1 matchup.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double WinProbability(Rating a, Rating b)
        {
            var deltaMu = a.Mean - b.Mean;
            var sumSigma = Math.Pow(a.StandardDeviation, 2) + Math.Pow(b.StandardDeviation, 2);
            var denom = Math.Sqrt(2 * Math.Pow(_gameInfo.Beta, 2) + sumSigma);
            return Phi(deltaMu / denom);
        }

        /// <summary>
        /// Cumulative density function (CDF).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }
}
