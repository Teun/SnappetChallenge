using Moserware.Skills;
using SnappetTrueskill.Data;
using SnappetTrueskill.Science;
using System;
using System.Linq;

namespace SnappetTrueskill
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Initialize repositories
            var interactions = new ExerciseInteractionCsvRepository("../../../../../Data/work.csv");
            var users = new InMemoryUserRepository();
            var exercises = new InMemoryExerciseRepository();
            var eventRepo = new TrueskillEventCsvRepository("../../../../../Data/events.csv");

            // Define the game configuration
            var gameInfo = GameInfo.DefaultGameInfo;
            // Draws are not possible so disable them
            gameInfo.DrawProbability = 0;
            // Increase dynamics to make ratings more volatile
            gameInfo.DynamicsFactor *= 3;

            // Define the end of the training set
            var endDate = new DateTime(2015, 03, 24, 0, 0, 0, 0, DateTimeKind.Utc);

            // Replay all previous interactions to build users and exercises tables
            // Normally this would of course be saved in some sort of persistent database
            var replayer = new InteractionReplayer(users, exercises, interactions, eventRepo, gameInfo);
            replayer.Replay(endDate);

            // Print current user's scores
            foreach (var user in users.GetAll().OrderBy(x => x.Ratings["Rekenen"].ConservativeRating))
                Console.WriteLine($"{user.Id}: [MU] {user.Ratings["Rekenen"].Mean:N2} [SIGMA] {user.Ratings["Rekenen"].StandardDeviation:N2} [RATING] {user.Ratings["Rekenen"].ConservativeRating:N2}");

            // Print user and exercise mean mu
            Console.WriteLine($"Mean mu of a user: {users.GetAll().Sum(x => x.Ratings["Rekenen"].Mean) / users.GetAll().Count():N2}");
            Console.WriteLine($"Mean mu of an exercise: {exercises.GetAll().Where(x => x.Subject == "Rekenen").Sum(x => x.Rating.Mean) / exercises.GetAll().Where(x => x.Subject == "Rekenen").Count():N2}");

            // Predict the outcome for the interactions after `endDate` to test performance
            var performancePredictor = new PerformancePredictor(users, exercises, interactions, eventRepo, gameInfo);
            performancePredictor.PredictOnTestSet(endDate);

            Console.WriteLine("Done");
        }
    }
}
