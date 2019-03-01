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

            // Define the game configuration
            var gameInfo = GameInfo.DefaultGameInfo;
            // Draws are not possible so disable them
            gameInfo.DrawProbability = 0;
            // Increase dynamics to make ratings more volatile
            gameInfo.DynamicsFactor *= 5;

            // Define the end of the training set
            var endDate = new DateTime(2015, 03, 24, 12, 42, 50, 613, DateTimeKind.Utc);

            // Replay all previous interactions to build users and exercises tables
            // Normally this would of course be saved in some sort of persistent database
            var replayer = new InteractionReplayer(users, exercises, interactions, gameInfo);
            replayer.Replay(endDate);

            // Print current user's scores
            foreach (var user in users.GetAll().OrderBy(x => x.Rating.ConservativeRating))
                Console.WriteLine($"{user.Id}: [MU] {user.Rating.Mean:N2} [SIGMA] {user.Rating.StandardDeviation:N2} [RATING] {user.Rating.ConservativeRating:N2}");

            // Predict the outcome for the interactions after `endDate` to test performance
            // todo


            Console.WriteLine("Done");
        }
    }
}
