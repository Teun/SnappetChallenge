using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using snappet.core.Models.EF;

namespace snappet.core.Helpers
{
    public class Initializer
    {
        public static bool Seed(string dataLocation)
        {

            using (SnappetEntities db = new SnappetEntities())
            {
                //check if the database is empty at the moment - just check for a user. if there's no user then we can continue with seeding the DB
                User test = db.Users.FirstOrDefault();
                if (test != null)
                {
                    return true;
                }

                using (StreamReader reader = new StreamReader(dataLocation))
                {
                    string json = reader.ReadToEnd();
                    List<EntryItem> items = JsonConvert.DeserializeObject<List<EntryItem>>(json);

                    List<User> users = items.Select(entryItem => new User()
                    {
                        UserID = entryItem.UserId
                    }).GroupBy(x => x.UserID).Select(x => x.First()).ToList();




                    List<LearningObjective> learningObjectives = items.Select(entryItem => new LearningObjective()
                    {
                        LearningObjective1 = entryItem.LearningObjective,
                        Subject = entryItem.Subject,
                        Domain = entryItem.Domain
                    }).GroupBy(x => x.LearningObjective1).Select(x => x.First()).ToList();



                    List<SubmittedAnswer> submittedAnswers = items.Select(entryItem => new SubmittedAnswer()
                    {
                        SubmittedAnswerID = entryItem.SubmittedAnswerId,
                        Correct = entryItem.Correct == 1,
                        Progress = entryItem.Progress,
                        UserID = entryItem.UserId,
                        SubmittedAnswerDateTime = entryItem.SubmitDateTime,
                        ExerciseID = entryItem.ExerciseId
                    }).Distinct().ToList();



                    try
                    {
                        db.Users.AddRange(users);
                        db.LearningObjectives.AddRange(learningObjectives);


                        db.SaveChanges();

                        List<Exercise> exercises = items.Select(entryItem => new Exercise()
                        {
                            ID = entryItem.ExerciseId,
                            Difficulty = entryItem.Difficulty == "NULL" ? (double?)null : Convert.ToDouble(entryItem.Difficulty),
                            LearningObjectiveID = db.LearningObjectives.First(x => x.LearningObjective1 == entryItem.LearningObjective).LearningObjectiveID
                        }).GroupBy(x => x.ID).Select(x => x.First()).ToList();


                        db.Exercises.AddRange(exercises);
                        // db.SaveChanges();
                        db.SubmittedAnswers.AddRange(submittedAnswers);
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }


                return true;
            }
        }

        public class EntryItem
        {
            public int SubmittedAnswerId { get; set; }
            public DateTime SubmitDateTime { get; set; }
            public int Correct { get; set; }
            public int Progress { get; set; }
            public int UserId { get; set; }
            public int ExerciseId { get; set; }
            public string Difficulty { get; set; }
            public string Subject { get; set; }
            public string Domain { get; set; }
            public string LearningObjective { get; set; }

        }
    }
}